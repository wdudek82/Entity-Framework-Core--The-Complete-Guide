using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WizLib_DataAccess;
using WizLib_Models.Models;
using WizLib_Models.ViewModels;

namespace WizLibApp.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var books = _db.Books.ToList();
            return View(books);
        }

        public IActionResult PlayGround()
        {
            return Ok();
        }

        public IActionResult Upsert(int? id)
        {
            var book = new BookVM();
            book.PublisherList = _db.Publishers
                .Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Publisher_Id.ToString()
                })
                .ToList();

            if (id == null)
            {
                return View(book);
            }

            book.Book = _db.Books.FirstOrDefault(b => b.Book_Id == id);

            if (book.Book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BookVM obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }

            if (obj.Book == null)
            {
                // _db.Books.Add(obj);
            }
            else
            {
                // _db.Books.Update(obj);
            }

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details()
        {
            return Ok();
        }
        public IActionResult ManageAuthors()
        {
            return Ok();
        }

        public IActionResult Delete(int id)
        {
            var book = _db.Books.FirstOrDefault(b => b.Book_Id == id);

            if (book != null)
            {
                _db.Books.Remove(book);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
