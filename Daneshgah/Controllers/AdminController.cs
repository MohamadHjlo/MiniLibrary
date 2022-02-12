using System;
using System.Globalization;
using System.Linq;
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
    public class AdminController : Controller
    {
        private readonly WebsiteContext _siteContext;

        public AdminController(WebsiteContext siteContext)
        {
            _siteContext = siteContext;

        }
        public IActionResult Index()
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }

            var users = _siteContext.Users.ToList();
            return View(users); 
        }
        public IActionResult AddUser()
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(AddEditUserViewModel model)
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Name = model.Name,
                    Family = model.Family,
                    Email = model.Email,
                    BirthDate = int.Parse(model.BirthDate),
                    Password = model.Password,
                    RegisterDate = DateTime.Now
                };
                _siteContext.Users.Add(user);
                _siteContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult EditUser(int userId)
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }
            if (userId > 0)
            {
                var user = _siteContext.Users.FirstOrDefault(u => u.Id == userId);

                if (user != null)
                {
                    var edituser = new AddEditUserViewModel()
                    {
                        Name = user.Name,
                        Family = user.Family,
                        Email = user.Email,
                        BirthDate = user.BirthDate.ToString(),
                        Password = user.Password,
                        ID = user.Id
                    };
                    return View(edituser);
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult EditUser(AddEditUserViewModel model)
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }
            if (ModelState.IsValid)
            {
                var user = _siteContext.Users.FirstOrDefault(p => p.Id == model.ID);
                if (user == null) return View(model);
                user.Name = model.Name;
                user.Family = model.Family;
                user.Password = model.Password;
                user.Email = model.Email;
                user.BirthDate = int.Parse(model.BirthDate);
                _siteContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult DeleteUser(int userId)
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }
            var user = _siteContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)                                                          
            {
                var AmanatHaYeKarbar = _siteContext.Deposits.Where(d => d.UserId == userId).ToList();
                foreach (var amanat in AmanatHaYeKarbar)
                {
                    _siteContext.Deposits.Remove(amanat);
                }
                _siteContext.Users.Remove(user);
                _siteContext.SaveChanges();

                ViewData["SuccessDelete"] = $" کاربر {user.Name} با موفقیت حذف شد";
            }
            return View("Index", _siteContext.Users.ToList());
        }

        public IActionResult FindUser(string searchkey)
        {
            if (string.IsNullOrEmpty(searchkey))
            {
                return RedirectToAction("Index");
            }
            var users = _siteContext.Users.Where(u => u.Name.Contains(searchkey)).ToList();
            return View("Index", users);
        }

        public IActionResult GetAmanatHayeDirTahvildade(int userId)
        {
            var amanatHa = _siteContext.Deposits.Where(a => a.UserId == userId && a.IsDelivered == true).Include(a => a.Book).ToList();
            var beMogheTahvilNadade = amanatHa.Where(a => a.RespiteTime < DateTime.Now).ToList();
            return View("Non-performingDeposites", beMogheTahvilNadade);
        }

        public IActionResult Books()
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }

            var books = _siteContext.Books.ToList();
            return View(books);
        }

        public IActionResult AddBook()
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(AddEditItemsViewModel model)
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var datetime = new DateTime(model.PublicationYear, model.PublicationMounth, model.PublicationDate);
                    var book = new Book()
                    {
                        Title = model.Title,
                        Topic = model.Topic,
                        ISBN = model.ISBN,
                        PageCount = model.PageCount,
                        Publisher = model.Publisher,
                        PublicationYear = datetime.ToMiladi()
                    };

                    _siteContext.Books.Add(book);
                    _siteContext.SaveChanges();
                    return RedirectToAction("Books");
                }
                catch
                {
                    ViewData["ErrorMessage"] = "تاریخ معتبر نمی باشد";
                    return View(model);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult EditBook(int bookId)
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }
            if (bookId > 0)
            {
                var book = _siteContext.Books.FirstOrDefault(u => u.Id == bookId);

                PersianCalendar pc = new PersianCalendar();

                var shamsiyear = pc.GetYear(book.PublicationYear);
                var shamsimonth = pc.GetMonth(book.PublicationYear);
                var shamsiday = pc.GetDayOfMonth(book.PublicationYear);

                if (book != null)
                {
                    var editBook = new AddEditItemsViewModel()
                    {
                        Title = book.Title,
                        Topic = book.Topic,
                        ISBN = book.ISBN,
                        PageCount = book.PageCount,
                        Publisher = book.Publisher,
                        PublicationYear = shamsiyear,
                        PublicationMounth = shamsimonth,
                        PublicationDate = shamsiday,
                        Id = book.Id
                    };
                    return View(editBook);
                }
                return RedirectToAction("Books");
            }
            return RedirectToAction("Books");
        }
        [HttpPost]
        public IActionResult EditBook(AddEditItemsViewModel model)
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var book = _siteContext.Books.FirstOrDefault(p => p.Id == model.Id);
                    var datetime = new DateTime(model.PublicationYear, model.PublicationMounth, model.PublicationDate);
                    if (book == null) return View(model);
                    book.Topic = model.Topic;
                    book.Title = model.Title;
                    book.ISBN = model.ISBN;
                    book.PublicationYear = datetime.ToMiladi();
                    book.PageCount = model.PageCount;
                    book.Publisher = model.Publisher;
                    _siteContext.SaveChanges();

                    return RedirectToAction("Books");
                }
                catch
                {
                    return View(model);
                }
            }

            return View(model);
        }

        public IActionResult DeleteBook(int bookId)
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }
            var book = _siteContext.Books.FirstOrDefault(u => u.Id == bookId);
            if (book != null)                                                          
            {
                var amanatHaYeMahsool = _siteContext.Deposits.Where(d => d.UserId == bookId).ToList();
                foreach (var amanat in amanatHaYeMahsool)
                {
                    _siteContext.Deposits.Remove(amanat);
                }
                _siteContext.Books.Remove(book);
                _siteContext.SaveChanges();

                ViewData["SuccessDelete"] = $" کتاب با شناسه {book.Id} با موفقیت حذف شد";
            }
            return View("Books", _siteContext.Books.ToList());
        }

        /// <summary>
        ///****************************************                         مقالات                       ////////****************************************  
        /// </summary>
        /// <returns></returns>
        public IActionResult Articles()//مقالات
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }

            var articles = _siteContext.Articles.ToList();
            return View(articles);
        }

        public IActionResult AddArticle()
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddArticle(AddEditItemsViewModel model)
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var datetime = new DateTime(model.PublicationYear, model.PublicationMounth, model.PublicationDate);
                    var article = new Article()
                    {
                        Title = model.Title,
                        Topic = model.Topic,
                        ISBN = model.ISBN,
                        PageCount = model.PageCount,
                        Publisher = model.Publisher,
                        PublicationYear = datetime.ToMiladi()
                    };

                    _siteContext.Articles.Add(article);
                    _siteContext.SaveChanges();
                    return RedirectToAction("Articles");
                }
                catch
                {
                    ViewData["ErrorMessage"] = "تاریخ معتبر نمی باشد";
                    return View(model);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult EditArticle(int articleId)
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }
            if (articleId > 0)
            {
                var article = _siteContext.Articles.FirstOrDefault(u => u.Id == articleId);

                PersianCalendar pc = new PersianCalendar();

                var shamsiyear = pc.GetYear(article.PublicationYear);
                var shamsimonth = pc.GetMonth(article.PublicationYear);
                var shamsiday = pc.GetDayOfMonth(article.PublicationYear);

                if (article != null)
                {
                    var editArticle = new AddEditItemsViewModel()
                    {
                        Title = article.Title,
                        Topic = article.Topic,
                        ISBN = article.ISBN,
                        PageCount = article.PageCount,
                        Publisher = article.Publisher,
                        PublicationYear = shamsiyear,
                        PublicationMounth = shamsimonth,
                        PublicationDate = shamsiday,
                        Id = article.Id
                    };
                    return View(editArticle);
                }
                return RedirectToAction("Articles");
            }
            return RedirectToAction("Articles");
        }
        [HttpPost]
        public IActionResult EditArticle(AddEditItemsViewModel model)
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var article = _siteContext.Articles.FirstOrDefault(p => p.Id == model.Id);
                    var datetime = new DateTime(model.PublicationYear, model.PublicationMounth, model.PublicationDate);
                    if (article == null) return View(model);
                    article.Topic = model.Topic;
                    article.Title = model.Title;
                    article.ISBN = model.ISBN;
                    article.PublicationYear = datetime.ToMiladi();
                    article.PageCount = model.PageCount;
                    article.Publisher = model.Publisher;
                    _siteContext.SaveChanges();

                    return RedirectToAction("Articles");
                }
                catch
                {
                    ViewData["ErrorMessage"] = "تاریخ معتبر نمی باشد";
                    return View(model);
                }
            }

            return View(model);
        }

        public IActionResult DeleteArticle(int articleId)
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }
            var article = _siteContext.Articles.FirstOrDefault(u => u.Id == articleId);
            if (article != null)
            {
                _siteContext.Articles.Remove(article);
                _siteContext.SaveChanges();

                ViewData["SuccessDelete"] = $" مقاله با شناسه {article.Id} با موفقیت حذف شد";
            }
            return View("Articles", _siteContext.Articles.ToList());
        }

        /// <summary>
        ///****************************************                         مجلات                       ////////****************************************  
        /// </summary>
        /// <returns></returns>

        public IActionResult Journals()
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }

            var journals = _siteContext.Journals.ToList();
            return View(journals);
        }

        public IActionResult AddJournal()
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddJournal(AddEditItemsViewModel model)
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var datetime = new DateTime(model.PublicationYear, model.PublicationMounth, model.PublicationDate);
                    var journal = new Journal()
                    {
                        Title = model.Title,
                        Topic = model.Topic,
                        ISBN = model.ISBN,
                        PageCount = model.PageCount,
                        Publisher = model.Publisher,
                        PublicationYear = datetime.ToMiladi()
                    };

                    _siteContext.Journals.Add(journal);
                    _siteContext.SaveChanges();
                    return RedirectToAction("Journals");
                }
                catch
                {
                    return View(model);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult EditJournal(int journalId)
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }
            if (journalId > 0)
            {
                var journal = _siteContext.Journals.FirstOrDefault(u => u.Id == journalId);

                PersianCalendar pc = new PersianCalendar();
                var shamsiyear = pc.GetYear(journal.PublicationYear);
                var shamsimonth = pc.GetMonth(journal.PublicationYear);
                var shamsiday = pc.GetDayOfMonth(journal.PublicationYear);

                if (journal != null)
                {
                    var editJournal = new AddEditItemsViewModel()
                    {
                        Title = journal.Title,
                        Topic = journal.Topic,
                        ISBN = journal.ISBN,
                        PageCount = journal.PageCount,
                        Publisher = journal.Publisher,
                        PublicationYear = shamsiyear,
                        PublicationMounth = shamsimonth,
                        PublicationDate = shamsiday,
                        Id = journal.Id
                    };
                    return View(editJournal);
                }
                return RedirectToAction("Articles");
            }
            return RedirectToAction("Articles");
        }
        [HttpPost]
        public IActionResult EditJournal(AddEditItemsViewModel model)
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var journal = _siteContext.Journals.FirstOrDefault(p => p.Id == model.Id);
                    var datetime = new DateTime(model.PublicationYear, model.PublicationMounth, model.PublicationDate);
                    if (journal == null) return View(model);
                    journal.Topic = model.Topic;
                    journal.Title = model.Title;
                    journal.ISBN = model.ISBN;
                    journal.PublicationYear = datetime.ToMiladi();
                    journal.PageCount = model.PageCount;
                    journal.Publisher = model.Publisher;
                    _siteContext.SaveChanges();

                    return RedirectToAction("Journals");
                }
                catch
                {
                    ViewData["ErrorMessage"] = "تاریخ معتبر نمی باشد";
                    return View(model);
                }
            }

            return View(model);
        }

        public IActionResult DeleteJournal(int journalId)
        {
            if (User.FindFirstValue("IsAdmin") != "True")
            {
                return Redirect("/");
            }
            var journal = _siteContext.Journals.FirstOrDefault(u => u.Id == journalId);
            if (journal != null)
            {
                _siteContext.Journals.Remove(journal);
                _siteContext.SaveChanges();

                ViewData["SuccessDelete"] = $" مجله با شناسه {journal.Id} با موفقیت حذف شد";
            }
            return View("Journals", _siteContext.Journals.ToList());
        }
    }
}
