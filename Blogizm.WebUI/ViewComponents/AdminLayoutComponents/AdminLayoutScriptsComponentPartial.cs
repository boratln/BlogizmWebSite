using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebUI.ViewComponents.AdminLayoutComponents
{
    public class AdminLayoutScriptsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
