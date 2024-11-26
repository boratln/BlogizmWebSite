using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
