using Microsoft.AspNetCore.Mvc;

namespace WizLibApp.Controllers
{
    public class PublisherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
