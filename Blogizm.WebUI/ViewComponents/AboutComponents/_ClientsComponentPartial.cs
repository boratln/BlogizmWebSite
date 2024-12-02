using Blogizm.Dtos.ClientDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blogizm.WebUI.ViewComponents.AboutComponents
{
    public class _ClientsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ClientsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7023/api/Client/GetAllClient");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultClientDto>>(jsonData);
                return View(values);
            }
            return View(new ResultClientDto());
        }
    }
}
