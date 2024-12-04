using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult ChangeCulture(string culture, string returnUrl = "/")
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
