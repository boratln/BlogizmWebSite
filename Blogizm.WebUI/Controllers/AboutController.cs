using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
