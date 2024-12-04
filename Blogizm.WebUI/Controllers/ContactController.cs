using Blogizm.Dtos.ContactMessageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
namespace Blogizm.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(CreateContactMessageDto contactMessageDto)
        {
            contactMessageDto.IsReaded = false;
            contactMessageDto.CreatedDate = DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var Json=JsonConvert.SerializeObject(contactMessageDto);
            var content=new StringContent(Json,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7023/api/ContactMessage/CreateContactMessage", content);
            string? baslik = "";
            string? mesaj = "";
            string successorfailed = "";
            var responseData=await responseMessage.Content.ReadAsStringAsync();
            if (responseMessage.IsSuccessStatusCode)
            {
                
                baslik = "Mesaj Başarıyla Gönderildi";
                mesaj = "Mesajınız Başarıyla Yöneticimize Gönderilmiştir!";
                TempData["baslik"] = baslik;
                TempData["mesaj"] = mesaj;
                successorfailed = "success";
                TempData["icon"]=successorfailed;
                return RedirectToAction("Index", "Contact");
            }
            baslik = "Mesaj Gönderilemedi";
            mesaj = "Mesajınız Gönderilirken Bir Sorun Oluştu.Tekrar Deneyiniz!";
            successorfailed = "error";
            TempData["baslik"] = baslik;
            TempData["mesaj"] = mesaj;
            TempData["icon"] = successorfailed;

            return RedirectToAction("Index", "Contact");
        }
    }
}
