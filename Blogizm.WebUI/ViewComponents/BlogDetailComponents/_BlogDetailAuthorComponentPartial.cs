using Blogizm.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Blogizm.WebUI.ViewComponents.BlogDetailComponents
{
    public class _BlogDetailAuthorComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailAuthorComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task<IViewComponentResult> InvokeAsync(int blogid)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7023/api/Blog/GetAuthorByBlogId/"+blogid);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var author = JsonConvert.DeserializeObject<GetAuthorByBlogIdDto>(jsonData);
                return View(author);
            }
            return View();
        }
    }
}
