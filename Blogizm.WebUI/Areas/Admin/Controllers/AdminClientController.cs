using Blogizm.Dtos.ClientDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Blogizm.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminClient")]
    public class AdminClientController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminClientController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7023/api/Client/GetAllClient");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultClientDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("CreateClient")]
        [HttpGet]
        public IActionResult CreateClient()
        {
            return View();
        }
        [Route("CreateClient")]
        [HttpPost]
        public async Task<IActionResult> CreateClient(CreateClientDto ClientDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(ClientDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7023/api/Client/CreateClient", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "Referans Eklendi";
                TempData["mesaj"] = "Referans başarılı bir şekilde eklendi";
                return RedirectToAction("Index", "AdminClient", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminClient", new { area = "Admin" });

        }
        [Route("RemoveClient/{id}")]
        public async Task<IActionResult> RemoveClient(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7023/api/Client/DeleteClient/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "Referans Silindi";
                TempData["mesaj"] = "Referans başarılı bir şekilde silindi";
                return RedirectToAction("Index", "AdminClient", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminClient", new { area = "Admin" });
        }
        [Route("UpdateClient/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateClient(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7023/api/Client/GetClient/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateClientDto>(jsonData);


                return View(value);
            }
            return View(new UpdateClientDto());

        }
        [Route("UpdateClient/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateClient(UpdateClientDto ClientDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(ClientDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7023/api/Client/UpdateClient", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "Referans Güncellendi";
                TempData["mesaj"] = "Referans başarılı bir şekilde güncellendi";
                return RedirectToAction("Index", "AdminClient", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminClient", new { area = "Admin" });
        }
    }
}
