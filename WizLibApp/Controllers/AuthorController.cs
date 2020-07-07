using Microsoft.AspNetCore.Mvc;
using WizLib_Models.Models;

namespace WizLibApp.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Author obj)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
