using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebUI.ViewComponents.AdminLayoutComponents
{
    public class AdminLayoutSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
