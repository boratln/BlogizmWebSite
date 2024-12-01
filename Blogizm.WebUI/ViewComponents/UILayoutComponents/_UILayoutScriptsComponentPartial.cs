using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutScriptsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
