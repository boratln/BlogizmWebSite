using Blogizm.Dtos.SocialMediaDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Blogizm.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminSocialMedia")]
    public class AdminSocialMediaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminSocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7023/api/SocialMedia/GetAllSocialMedia");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("CreateSocialMedia")]
        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }
        [Route("CreateSocialMedia")]
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto SocialMediaDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(SocialMediaDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7023/api/SocialMedia/CreateSocialMedia", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "Sosyal Medya Eklendi";
                TempData["mesaj"] = "Sosyal Medya başarılı bir şekilde eklendi";
                return RedirectToAction("Index", "AdminSocialMedia", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminSocialMedia", new { area = "Admin" });

        }
        [Route("RemoveSocialMedia/{id}")]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7023/api/SocialMedia/DeleteSocialMedia/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "Sosyal Medyai Silindi";
                TempData["mesaj"] = "Sosyal Medya başarılı bir şekilde silindi";
                return RedirectToAction("Index", "AdminSocialMedia", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminSocialMedia", new { area = "Admin" });
        }
        [Route("UpdateSocialMedia/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7023/api/SocialMedia/GetSocialMedia/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateSocialMediaDto>(jsonData);


                return View(value);
            }
            return View(new UpdateSocialMediaDto());

        }
        [Route("UpdateSocialMedia/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto SocialMediaDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(SocialMediaDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7023/api/SocialMedia/UpdateSocialMedia", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "Sosyal Medya Güncellendi";
                TempData["mesaj"] = "Sosyal Medya başarılı bir şekilde güncellendi";
                return RedirectToAction("Index", "AdminSocialMedia", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminSocialMedia", new { area = "Admin" });
        }
    }
}
