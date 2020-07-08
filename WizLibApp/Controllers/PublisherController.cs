using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WizLib_DataAccess;
using WizLib_Models.Models;

namespace WizLibApp.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PublisherController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var publishers = _db.Publishers.ToList();
            return View(publishers);
        }

        public IActionResult Upsert(int? id)
        {
            var publisher = new Publisher();

            if (id != null)
            {
                publisher = _db.Publishers.FirstOrDefault(p => p.Publisher_Id == id);
            }

            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Publisher obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }

            if (obj.Publisher_Id == 0)
            {
                _db.Publishers.Add(obj);
            }
            else
            {
                _db.Publishers.Update(obj);
            }

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var publisher = _db.Publishers.FirstOrDefault(p => p.Publisher_Id == id);

            if (publisher != null)
            {
                _db.Publishers.Remove(publisher);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
