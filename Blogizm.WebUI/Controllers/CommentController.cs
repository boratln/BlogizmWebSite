using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebUI.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult CreateComment()
        {
            return View();
        }
    }
}
