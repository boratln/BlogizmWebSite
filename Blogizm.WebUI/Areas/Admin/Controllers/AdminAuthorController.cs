using Blogizm.Dtos.AuthorDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Blogizm.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminAuthor")]
    public class AdminAuthorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminAuthorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7023/api/Author/GetAllAuthor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("CreateAuthor")]
        [HttpGet]
        public IActionResult CreateAuthor()
        {
            return View();
        }
        [Route("CreateAuthor")]
        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDto AuthorDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(AuthorDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7023/api/Author/CreateAuthor", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "Yazar Eklendi";
                TempData["mesaj"] = "Yazar başarılı bir şekilde eklendi";
                return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });

        }
        [Route("RemoveAuthor/{id}")]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7023/api/Author/DeleteAuthor/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "Yazar Silindi";
                TempData["mesaj"] = "Yazar başarılı bir şekilde silindi";
                return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
        }
        [Route("UpdateAuthor/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateAuthor(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7023/api/Author/GetAuthor/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateAuthorDto>(jsonData);


                return View(value);
            }
            return View(new UpdateAuthorDto());

        }
        [Route("UpdateAuthor/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto AuthorDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(AuthorDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7023/api/Author/UpdateAuthor", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "Yazar Güncellendi";
                TempData["mesaj"] = "Yazar başarılı bir şekilde güncellendi";
                return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
        }
    }
}
