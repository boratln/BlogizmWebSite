using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebUI.ViewComponents.BlogDetailComponents
{
    public class _BlogDetailAddCommentComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
