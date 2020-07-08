using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WizLib_DataAccess;
using WizLib_Models.Models;

namespace WizLibApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET
        public IActionResult Index()
        {
            var categories = _db.Categories.ToList();
            return View(categories);
        }

        public IActionResult Upsert(int? id)
        {
            var category = id == null
                ? new Category()
                : _db.Categories.FirstOrDefault(c => c.Category_Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Category_Id == 0)
                {
                    _db.Categories.Add(obj);
                }
                else
                {
                    _db.Categories.Update(obj);
                }

                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Category_Id == id);

            if (category != null)
            {
                _db.Remove(category);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple2()
        {
            var categories = Enumerable.Range(1, 2)
                .Select(i => new Category {Name = Guid.NewGuid().ToString()}).ToList();

            _db.Categories.AddRange(categories);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple5()
        {
            var categories = Enumerable.Range(1, 5)
                .Select(i => new Category {Name = Guid.NewGuid().ToString()}).ToList();

            _db.Categories.AddRange(categories);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple2()
        {
            var categories = _db.Categories.OrderByDescending(c => c.Category_Id).Take(2).ToList();
            _db.RemoveRange(categories);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple5()
        {
            var categories = _db.Categories.OrderByDescending(c => c.Category_Id).Take(5).ToList();
            _db.RemoveRange(categories);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
