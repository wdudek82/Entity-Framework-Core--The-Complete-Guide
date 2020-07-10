using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WizLib_DataAccess;
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
            var books = _db.Books
                .Include(b => b.Publisher)
                .ToList();
            // foreach (var book in books)
            // {
            //     // Least efficient
            //     // book.Publisher = _db.Publishers.FirstOrDefault(b => b.Publisher_Id == book.Publisher_Id);
            //
            //     // Explicit loading - more efficient
            //     _db.Entry(book).Reference(b => b.Publisher).Load();
            // }

            return View(books);
        }

        public IActionResult PlayGround()
        {
            var bookTemp = _db.Books.FirstOrDefault();
            bookTemp.Price = 100;

            var bookCollection = _db.Books;
            double totalPrice = 0;

            foreach (var book in bookCollection)
            {
                totalPrice += book.Price;
            }

            var bookList = _db.Books.ToList();
            foreach (var book in bookList)
            {
                totalPrice += book.Price;
            }

            var bookCollection2 = _db.Books;
            var bookCount1 = bookCollection2.Count();

            var bookCount2 = _db.Books.Count();

            return RedirectToAction(nameof(Index));
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
            // if (!ModelState.IsValid)
            // {
            //     return View(obj);
            // }

            if (obj.Book.Book_Id == 0)
            {
                _db.Books.Add(obj.Book);
            }
            else
            {
                _db.Books.Update(obj.Book);
            }

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            BookVM obj = new BookVM();

            if (id == null)
            {
                return View(obj);
            }

            // this is for edit
            obj.Book = _db.Books.Include(b => b.BookDetail).FirstOrDefault(b => b.Book_Id == id);
            // obj.Book!.BookDetail = _db.BookDetails.FirstOrDefault(b => b.BookDetail_Id == obj.Book.BookDetail_Id);

            if (obj.Book == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(BookVM obj)
        {
            if (obj.Book.BookDetail.BookDetail_Id == 0)
            {
                _db.BookDetails.Add(obj.Book.BookDetail);

                var bookFromDb = _db.Books.FirstOrDefault(b => b.Book_Id == obj.Book.Book_Id);
                bookFromDb!.BookDetail_Id = obj.Book.BookDetail_Id;

                _db.SaveChanges();
            }
            else
            {
                _db.BookDetails.Update(obj.Book.BookDetail);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
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
