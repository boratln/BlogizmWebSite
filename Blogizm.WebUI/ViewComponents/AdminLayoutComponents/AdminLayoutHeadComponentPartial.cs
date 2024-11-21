using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebUI.ViewComponents.AdminLayoutComponents
{
    public class AdminLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
