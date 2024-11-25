using Blogizm.Dtos.ContactMessageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Blogizm.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminContactMessage")]
    public class AdminContactMessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactMessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7023/api/ContactMessage/GetContactMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactMessageDto>>(jsonData);
                return View(values);
            }
            return View();
        }
   
        [Route("RemoveContactMessage/{id}")]
        public async Task<IActionResult> RemoveContactMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7023/api/ContactMessage/RemoveContactMessage/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "Mesaj Silindi";
                TempData["mesaj"] = "Mesaj başarılı bir şekilde silindi";
                return RedirectToAction("Index", "AdminContactMessage", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminContactMessage", new { area = "Admin" });
        }
 
    }
}
