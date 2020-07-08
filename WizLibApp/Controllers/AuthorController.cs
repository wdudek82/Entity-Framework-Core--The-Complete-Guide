using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WizLib_DataAccess;
using WizLib_Models.Models;

namespace WizLibApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var authors = _db.Authors.ToList();
            return View(authors);
        }

        public IActionResult Upsert(int? id)
        {
            var author = new Author();

            if (id != null)
            {
                author = _db.Authors.FirstOrDefault(a => a.Author_Id == id);
            }

            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Author obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }

            if (obj.Author_Id == 0)
            {
                _db.Authors.Add(obj);
            }
            else
            {
                _db.Authors.Update(obj);
            }

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var author = _db.Authors.FirstOrDefault(a => a.Author_Id == id);

            if (author != null)
            {
                _db.Authors.Remove(author);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
