using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;

namespace Blogizm.WebUI.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // HttpContext.Items içinden kültürleri al
            var supportedCultures = HttpContext.Items["SupportedCultures"] as List<CultureInfo>;
            ViewBag.SupportedCultures = supportedCultures;
            base.OnActionExecuting(context);
        }
    }
}
