using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Blogizm.WebUI.ViewComponents.BlogDetailComponents
{
    public class _BlogDetailAuthorComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
