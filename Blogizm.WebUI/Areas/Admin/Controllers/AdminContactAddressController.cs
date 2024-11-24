using Blogizm.Dtos.ContactAddressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Blogizm.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminContactAddress")]
    public class AdminContactAddressController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactAddressController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7023/api/ContactAddress/GetAllContactAddress");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactAddressDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("CreateContactAddress")]
        [HttpGet]
        public IActionResult CreateContactAddress()
        {
            return View();
        }
        [Route("CreateContactAddress")]
        [HttpPost]
        public async Task<IActionResult> CreateContactAddress(CreateContactAddressDto ContactAddressDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(ContactAddressDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7023/api/ContactAddress/CreateContactAddress", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "İletişim Adres Eklendi";
                TempData["mesaj"] = "İletişim Adres başarılı bir şekilde eklendi";
                return RedirectToAction("Index", "AdminContactAddress", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminContactAddress", new { area = "Admin" });

        }
        [Route("RemoveContactAddress/{id}")]
        public async Task<IActionResult> RemoveContactAddress(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7023/api/ContactAddress/DeleteContactAddress/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "İletişim Adresi Silindi";
                TempData["mesaj"] = "İletişim Adres başarılı bir şekilde silindi";
                return RedirectToAction("Index", "AdminContactAddress", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminContactAddress", new { area = "Admin" });
        }
        [Route("UpdateContactAddress/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateContactAddress(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7023/api/ContactAddress/GetContactAddress/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateContactAddressDto>(jsonData);


                return View(value);
            }
            return View(new UpdateContactAddressDto());

        }
        [Route("UpdateContactAddress/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateContactAddress(UpdateContactAddressDto ContactAddressDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(ContactAddressDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7023/api/ContactAddress/UpdateContactAddress", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "İletişim Adres Güncellendi";
                TempData["mesaj"] = "İletişim Adres başarılı bir şekilde güncellendi";
                return RedirectToAction("Index", "AdminContactAddress", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminContactAddress", new { area = "Admin" });
        }
    }
}
