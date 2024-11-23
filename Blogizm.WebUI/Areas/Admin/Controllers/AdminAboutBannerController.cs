using Blogizm.Dtos.AboutBannerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Blogizm.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminAboutBanner")]
    public class AdminAboutBannerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminAboutBannerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7023/api/AboutBanner/GetAllAboutBanner");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutBannerDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("CreateAboutBanner")]
        [HttpGet]
        public IActionResult CreateAboutBanner()
        {
            return View();
        }
        [Route("CreateAboutBanner")]
        [HttpPost]
        public async Task<IActionResult> CreateAboutBanner(CreateAboutBannerDto AboutBannerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(AboutBannerDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7023/api/AboutBanner/CreateAboutBanner", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "Hakkımızda Banner kısmı Eklendi";
                TempData["mesaj"] = "Hakkımızda Banner kısmı başarılı bir şekilde eklendi";
                return RedirectToAction("Index", "AdminAboutBanner", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminAboutBanner", new { area = "Admin" });

        }
        [Route("RemoveAboutBanner/{id}")]
        public async Task<IActionResult> RemoveAboutBanner(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7023/api/AboutBanner/DeleteAboutBanner/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "Hakkımızda Banner kısmı Silindi";
                TempData["mesaj"] = "Hakkımızda Banner kısmı başarılı bir şekilde silindi";
                return RedirectToAction("Index", "AdminAboutBanner", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminAboutBanner", new { area = "Admin" });
        }
        [Route("UpdateAboutBanner/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateAboutBanner(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7023/api/AboutBanner/GetAboutBanner/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateAboutBannerDto>(jsonData);


                return View(value);
            }
            return View(new UpdateAboutBannerDto());

        }
        [Route("UpdateAboutBanner/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateAboutBanner(UpdateAboutBannerDto AboutBannerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(AboutBannerDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7023/api/AboutBanner/UpdateAboutBanner", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "Hakkımızda Banner kısmı Güncellendi";
                TempData["mesaj"] = "Hakkımızda Banner kısmı başarılı bir şekilde güncellendi";
                return RedirectToAction("Index", "AdminAboutBanner", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminAboutBanner", new { area = "Admin" });
        }
    }
}
