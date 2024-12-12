using Blogizm.Dtos.BlogDetailDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blogizm.WebUI.ViewComponents.BlogDetailComponents
{
    public class _BlogDetailPopularPostComponentPartial:ViewComponent

    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailPopularPostComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int blogid, int categoryid)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7023/api/Blog/Get3BlogByCategoryIdinNotCurrentBlogId/{categoryid}/{blogid}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Get3BlogByCategoryIdinNotCurrentBlogIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
