using Blog.Models;
using Blog.Models.DAL;
using Blog.Models.Entities;
using Blog.Models.ViewModel;
using Blog.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Blog.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly SignInManager<User> signInManager;
        private readonly IUserService _userService;
        public readonly IEmailService _emailService;
		private readonly Context _db;

		public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, IPasswordHasher<User> passwordHasher, IUserService userService, IEmailService emailService,Context db)
        {
            this.signInManager = signInManager;
            this.passwordHasher = passwordHasher;
            this.userManager = userManager;
            this._userService = userService;
            this._emailService = emailService;
            _db = db;
        }
		public IActionResult WriteArticle()
		{
			return View();
		}

        [HttpPost]
		public IActionResult WriteArticle(int id)
		{
        
			return View();
		}
		public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (string.IsNullOrWhiteSpace(vm.Email) || string.IsNullOrWhiteSpace(vm.Password))
            {
                return View("Login", vm);
            }
            else if (ModelState.IsValid)
            {
                User user = await userManager.FindByEmailAsync(vm.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user, vm.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View(vm);
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (ModelState.IsValid)
            {
                User appUser = new User()
                {
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    UserName = vm.UserName,
                    Email = vm.Email,
                    BirthDate = vm.BirthDate
                };
                bool EmailInUse = _userService.IsEmailInUse(appUser.Email);
                if (!EmailInUse)
                {
                    IdentityResult identityResult = await userManager.CreateAsync(appUser, vm.Password);
                    var confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(appUser);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account",
                        new { userId = appUser.Id, token = confirmationToken }, Request.Scheme
                        );
                    string subject = "Confirmation";
                    string content = "Confirmation link:  " + confirmationLink;
                    SendEmail(appUser.Email, content, subject);

                    await userManager.AddToRoleAsync(appUser, "Standard");
                    TempData["Message"] = "Registration successful, before you can Login, please confirm your email by clicking on the confirmation link we've sent to your email adress.";

                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    TempData["Message"] = "This email address is already being used.";
                }
            }
            return View(vm);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"The User ID {userId} is invalid";
                return View("Error");
            }
            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ErrorTitle = "Email can not be confirmed.";
            return View("Error");
        }
        public void SendEmail(string email, string content, string subject)
        {
			var message = new Message(new string[] { email }, subject, content);
			_emailService.SendEmail(message);
		}
        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM vm)
        {
			var user = await userManager.FindByEmailAsync(vm.Email);
			if (user != null && await userManager.IsEmailConfirmedAsync(user))
			{
				var passwordToken = await userManager.GeneratePasswordResetTokenAsync(user);
				var resetLink = Url.Action("ResetPassword", "Account",
						new { email = user.Email, token = passwordToken }, Request.Scheme
						);
				string content = "Password reset link:  " + resetLink;
				SendEmail(user.Email, content, "Password Reset");
				TempData["Message"] = "Password reset link has been sent to your email adress.";
				return View();
			}
			TempData["Message"] = "Email address not found. If you think this is a mistake please make sure you've confirmed your email address.";
			return View();
		}
        public async Task<IActionResult> ResetPassword(string token, string email)
        {
			if (token == null || email == null)
			{
				ModelState.AddModelError("", "Invalid password reset token.");
			}

			return View();
		}
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM vm)
        {
			if (ModelState.IsValid)
			{
				var user = await userManager.FindByEmailAsync(vm.Email);
				if (user != null)
				{
					if (vm.Password == vm.ConfirmPassword)
					{
						var result = await userManager.ResetPasswordAsync(user, vm.Token, vm.Password);
						if (result.Succeeded)
						{
							TempData["Message"] = "Your Password has been successfully changed.";
							return View("Error");
						}
						foreach (var error in result.Errors)
						{
							ModelState.AddModelError("", error.Description);
						}
						return View(vm);
					}
					else
					{
						ModelState.AddModelError("", "Passwords don't match.");
						return View(vm);
					}
				}
				ViewBag.ErrorMessage = "User not found.";
				return View("NotFound");
			}
			return View(vm);
		}
        public IActionResult AccountSettings()
        {
            return View();
        }
        public async Task<IActionResult> ChangePassword(ChangeUserSettingsVM vm)
        {
            if (vm.Password != null)
            {
                User user = await userManager.GetUserAsync(User);
                if (user != null)
                {
                    await userManager.ChangePasswordAsync(user, vm.OldPassword, vm.Password);
                }
            }
            return View("AccountSettings");
        }
        //image secme yetismedi
        public async Task<IActionResult> ChangeImage(ChangeUserSettingsVM vm)
        {
            User user = await userManager.GetUserAsync(User);
            if (user != null)
            {

            }
            return RedirectToAction("Index", "Home");
        }
    }
}
