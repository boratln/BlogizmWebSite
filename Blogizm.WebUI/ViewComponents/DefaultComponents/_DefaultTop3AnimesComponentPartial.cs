using Blogizm.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blogizm.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultTop3AnimesComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpclientfactory;

        public _DefaultTop3AnimesComponentPartial(IHttpClientFactory httpclientfactory)
        {
            _httpclientfactory = httpclientfactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpclientfactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7023/api/Blog/GetTop3BlogByCategoryId/3");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTop3AnimesBlogDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
