using Blogizm.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blogizm.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutNavbarComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpclientfactory;

        public _UILayoutNavbarComponentPartial(IHttpClientFactory httpclientfactory)
        {
            _httpclientfactory = httpclientfactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpclientfactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7023/api/Category/GetAllCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
