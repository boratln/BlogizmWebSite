using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
