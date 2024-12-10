using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebUI.ViewComponents.BlogDetailComponents
{
    public class _BlogDetailCommentListComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
