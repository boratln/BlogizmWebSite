using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebUI.ViewComponents.BlogComponents
{
    public class _BlogSearchComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
