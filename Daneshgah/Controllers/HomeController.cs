using Daneshgah.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Daneshgah.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace Daneshgah.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly WebsiteContext _siteContext;
        private readonly ICookieRepository _cookieRepository;

        public HomeController(ILogger<HomeController> logger, WebsiteContext siteContext,ICookieRepository cookieRepository)
        {
            _logger = logger;
            _siteContext = siteContext;
            _cookieRepository = cookieRepository;
        }

        public IActionResult Index()
        {
            return Redirect("User/Index");
        }

        public IActionResult UserSignIn()
        {
            var model = new SignInViewModel();
            return View(model);
        }


        [HttpPost]
        public IActionResult UserSignIn(SignInViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            if (_siteContext.Users.Any(u => u.Name == model.Name || u.Email == model.Email))
            {
                ViewData["DuplicateError"] = "چنین کاربری با این نام یا ایمیل از قبل وجود دارد";
                return View(model);
            }
            var user = new User()
            {
                Name = model.Name,
                Family = model.Family,
                RegisterDate = DateTime.Now,
                Email = model.Email,
                BirthDate = int.Parse(model.BirthDate),
                Password = model.Password
            };
            _siteContext.Users.Add(user);
            _siteContext.SaveChanges();

            _cookieRepository.SetCookie(false,user,HttpContext); 
            

            return Redirect("/");
        }

        public IActionResult UserLogin()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult UserLogin(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = _siteContext.Users.FirstOrDefault(u => u.Name == model.Name && u.Password == model.Password && u.IsAdmin == true);
            if (user != null)
            {
                _cookieRepository.SetCookie(user.IsAdmin, user, HttpContext);

                return Redirect("/");
            }

            ViewData["NotFound"] = "چنین کاربری  وجود ندارد";
            return View(model);
        }
        public IActionResult AdminSignIn()
        {
            var model = new SignInViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult AdminSignIn(SignInViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            if (_siteContext.Users.Any(u => u.Name == model.Name || u.Email == model.Email))
            {
                ViewData["DuplicateError"] = "چنین کاربری با این نام یا ایمیل از قبل وجود دارد";
                return View(model);
            }
            var user = new User()
            {
                Name = model.Name,
                Family = model.Family,
                Email = model.Email,
                RegisterDate = DateTime.Now,
                BirthDate = int.Parse(model.BirthDate),
                Password = model.Password,
                IsAdmin = true
            };
            _siteContext.Users.Add(user);
            _siteContext.SaveChanges();

            _cookieRepository.SetCookie(user.IsAdmin, user, HttpContext);

            return Redirect("/");
        }

        public IActionResult AdminLogin()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult AdminLogin(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = _siteContext.Users.FirstOrDefault(u => u.Name == model.Name && u.Password == model.Password);
            if (user != null)
            {
                _cookieRepository.SetCookie(user.IsAdmin, user, HttpContext);

                return Redirect("/");
            }
            ViewData["NotFound"] = "چنین کاربری  وجود ندارد";
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Home/UserLogin");
        }
        public IActionResult Privacy()
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
