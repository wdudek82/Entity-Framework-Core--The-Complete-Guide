using Microsoft.AspNetCore.Mvc;
using WizLib_Models.Models;

namespace WizLibApp.Controllers
{
    public class PublisherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Publisher obj)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
