using Blog.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            return View();
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            return View();
        }
        public async Task<IActionResult> ConfirmEmail()
        {
            return View();
        }
        public async Task<IActionResult> SendEmail()
        {
            return View();
        }
        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM vm)
        {
            return View();
        }
        public async Task<IActionResult> ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM vm)
        {
            return View();
        }
    }
}
