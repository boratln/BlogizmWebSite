using Blogizm.Dtos.BlogDetailDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blogizm.WebUI.ViewComponents.BlogComponents
{
    public class _BlogPopularPostComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogPopularPostComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int categoryid)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7023/api/Blog/GetTop3BlogByCategoryId/" + categoryid);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Get3BlogByCategoryIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
