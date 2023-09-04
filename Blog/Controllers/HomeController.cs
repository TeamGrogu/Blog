using Blog.Models;
using Blog.Models.DAL;
using Blog.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly Context _db;
        private readonly MakaleVM _makaleVM;
        public HomeController(Context db, MakaleVM makaleVM)
        {
            _db = db;
            _makaleVM = makaleVM;
        }


        public IActionResult Index()
        {
            TempData["sayac"] = 0;

            _makaleVM.Makaleler = _db.Makales.OrderByDescending(m => m.CreateDate).ToList();
            _makaleVM.Konular = _db.Konus.ToList();
            return View(_makaleVM);
        }
		[HttpGet]
		public IActionResult BlogPost(int id)
		{
            _makaleVM.Makale = _db.Makales.Find(id);
            _makaleVM.Yazar = _db.Users.FirstOrDefault(x => x.Id == _makaleVM.Makale.YazarID);
            return View("BlogPost", _makaleVM);
		}

		public IActionResult About()
        {
            return View();
        }
        public IActionResult BlogList()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}