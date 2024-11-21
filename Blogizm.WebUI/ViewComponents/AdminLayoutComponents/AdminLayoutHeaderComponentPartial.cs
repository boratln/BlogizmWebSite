using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebUI.ViewComponents.AdminLayoutComponents
{
    public class AdminLayoutHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
