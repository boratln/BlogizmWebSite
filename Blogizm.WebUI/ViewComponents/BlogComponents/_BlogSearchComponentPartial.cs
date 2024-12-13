using Blogizm.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

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
