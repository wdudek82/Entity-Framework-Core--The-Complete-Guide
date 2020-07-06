using Microsoft.AspNetCore.Mvc;

namespace WizLibApp.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
