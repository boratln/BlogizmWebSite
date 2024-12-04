using Blogizm.Dtos.ContactMessageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blogizm.WebUI.ViewComponents.AdminLayoutComponents
{
    public class AdminLayoutNotificationsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminLayoutNotificationsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task  <IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7023/api/ContactMessage/ContactMessageWhereIsReadableFalseCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ContactMessageWhereIsReadableFalseCountDto>(jsonData);
                var count = value.MessageCount;
                ViewBag.count = count;
            }
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7023/api/ContactMessage/GetContactMessageWhereIsReadableFalse");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ContactMessageWhereIsReadableFalseDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
