using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebUI.ViewComponents.BlogComponents
{
    public class _BlogPopularPostComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
