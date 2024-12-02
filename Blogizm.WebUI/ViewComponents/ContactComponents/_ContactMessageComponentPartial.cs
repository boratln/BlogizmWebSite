using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebUI.ViewComponents.ContactComponents
{
    public class _ContactMessageComponentPartial:ViewComponent
    {
   
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
