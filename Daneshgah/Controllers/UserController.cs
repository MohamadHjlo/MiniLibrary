using System;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using Daneshgah.Data;
using Daneshgah.MethodHa.TabdilTarikh;
using Daneshgah.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Daneshgah.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly WebsiteContext _siteContext;

        public UserController(WebsiteContext siteContext)
        {
            _siteContext = siteContext;
        }

        public IActionResult Index()
        {
            var model = new UserViewModel
            {
                Books = _siteContext.Books.ToList(),
                Articles = _siteContext.Articles.ToList(),
                Journals = _siteContext.Journals.ToList()
            };
            return View(model);
        }

        public IActionResult Deposits()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var AmanatHa = _siteContext.Deposits.Where(a => a.UserId == userId && a.IsDelivered == false).Include(a => a.Book).ToList();
            return View(AmanatHa);
        }

        public IActionResult AddToDeposits(int bookId)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var amanat = new Deposit()
            {
                UserId = userId,
                BookId = bookId,
                RespiteTime = DateTime.Now.AddDays(3)
            };
            _siteContext.Deposits.Add(amanat);
            _siteContext.SaveChanges();
            return RedirectToAction("Deposits");
        }
        public IActionResult RemoveFromDeposits(int amanatId)
        {
            _siteContext.Deposits.FirstOrDefault(a => a.Id == amanatId)!.IsDelivered = true;

            return RedirectToAction("Deposits");
        }

        public IActionResult BookSearch(string searchKey, int groupId)
        {

            if (string.IsNullOrEmpty(searchKey))
            {
                return RedirectToAction("Index");
            }
            var model = new UserViewModel();

            switch (groupId)
            {
                case 1:
                    model.Books = _siteContext.Books.ToList().Where(b => b.Id.ToString().Contains(searchKey)).ToList();
                    break;
                case 2:
                    model.Books = _siteContext.Books.Where(b => b.Title.Contains(searchKey)).ToList();
                    break;
                case 3:
                    model.Books = _siteContext.Books.Where(b => b.Topic.Contains(searchKey)).ToList();
                    break;
                case 4:
                    model.Books = _siteContext.Books.ToList().Where(b => b.ISBN.ToString().Contains(searchKey)).ToList();
                    break;
                case 5:
                    model.Books = _siteContext.Books.ToList().Where(b => b.PageCount.ToString().Contains(searchKey)).ToList();
                    break;
                case 6:
                    model.Books = _siteContext.Books.ToList().Where(b => b.PublicationYear.ToShamsiCalender().Contains(searchKey)).ToList();
                    break;
                case 7:
                    model.Books = _siteContext.Books.Where(b => b.Publisher.Contains(searchKey)).ToList();
                    break;
                default:
                    model.Books = _siteContext.Books.ToList();
                    break;
            }
            return View("Index", model);
        }
        public IActionResult ArticleSearch(string searchKey, int groupId)
        {

            if (string.IsNullOrEmpty(searchKey))
            {
                return RedirectToAction("Index");
            }
            var model = new UserViewModel();

            switch (groupId)
            {
                case 1:
                    model.Articles = _siteContext.Articles.ToList().Where(b => b.Id.ToString().Contains(searchKey)).ToList();
                    break;
                case 2:
                    model.Articles = _siteContext.Articles.Where(b => b.Title.Contains(searchKey)).ToList();
                    break;
                case 3:
                    model.Articles = _siteContext.Articles.Where(b => b.Topic.Contains(searchKey)).ToList();
                    break;
                case 4:
                    model.Articles = _siteContext.Articles.ToList().Where(b => b.ISBN.ToString().Contains(searchKey)).ToList();
                    break;
                case 5:
                    model.Articles = _siteContext.Articles.ToList().Where(b => b.PageCount.ToString().Contains(searchKey)).ToList();
                    break;
                case 6:
                    model.Articles = _siteContext.Articles.ToList().Where(b => b.PublicationYear.ToShamsiCalender().Contains(searchKey)).ToList();
                    break;
                case 7:
                    model.Articles = _siteContext.Articles.Where(b => b.Publisher.Contains(searchKey)).ToList();
                    break;
                default:
                    model.Articles = _siteContext.Articles.ToList();
                    break;
            }

            return View("Index", model);
        }
        public IActionResult JournalSearch(string searchKey, int groupId)
        {

            if (string.IsNullOrEmpty(searchKey))
            {
                return RedirectToAction("Index");
            }
            var model = new UserViewModel();
            switch (groupId)
            {
                case 1:
                    model.Journals = _siteContext.Journals.ToList().Where(b => b.Id.ToString().Contains(searchKey)).ToList();
                    break;
                case 2:
                    model.Journals = _siteContext.Journals.Where(b => b.Title.Contains(searchKey)).ToList();
                    break;
                case 3:
                    model.Journals = _siteContext.Journals.Where(b => b.Topic.Contains(searchKey)).ToList();
                    break;
                case 4:
                    model.Journals = _siteContext.Journals.ToList().Where(b => b.ISBN.ToString().Contains(searchKey)).ToList();
                    break;
                case 5:
                    model.Journals = _siteContext.Journals.ToList().Where(b => b.PageCount.ToString().Contains(searchKey)).ToList();
                    break;
                case 6:
                    model.Journals = _siteContext.Journals.ToList().Where(b => b.PublicationYear.ToShamsiCalender().Contains(searchKey)).ToList();
                    break;
                case 7:
                    model.Journals = _siteContext.Journals.Where(b => b.Publisher.Contains(searchKey)).ToList();
                    break;
                default:
                    model.Journals = _siteContext.Journals.ToList();
                    break;
            }

            return View("Index", model);
        }
    }

}
