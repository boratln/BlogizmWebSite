using Blogizm.Dtos.BlogCategoryDtos;
using Blogizm.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Blogizm.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminBlogCategory")]
    public class AdminBlogCategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBlogCategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7023/api/BlogCategory/GetAllBlogCategoryWithGroupBy");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("CreateBlogCategory")]
        [HttpGet]
        public async Task< IActionResult> CreateBlogCategory()
        {
            var client = _httpClientFactory.CreateClient();
            var categoryResponse = await client.GetAsync("https://localhost:7023/api/Category/GetAllCategory");
            if (categoryResponse.IsSuccessStatusCode)
            {
                var categoryData = await categoryResponse.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryData);
                List<SelectListItem> categoryValues = (from x in values
                                                       select new SelectListItem
                                                       {
                                                           Value = x.CategoryId.ToString(),
                                                           Text = x.Name
                                                       }).ToList();
                ViewBag.categoryvalues = categoryValues;
            }
            return View();
        }
        [Route("CreateBlogCategory")]
        [HttpPost]
        public async Task<IActionResult> CreateBlogCategory(CreateBlogCategoryDto BlogCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();

       
            
            var json = JsonConvert.SerializeObject(BlogCategoryDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7023/api/BlogCategory", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "Blog Kategori Eklendi";
                TempData["mesaj"] = "Blog Kategori başarılı bir şekilde eklendi";
                return RedirectToAction("Index", "AdminBlogCategory", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminBlogCategory", new { area = "Admin" });

        }
        [Route("RemoveBlogCategory/{id}")]
        public async Task<IActionResult> RemoveBlogCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7023/api/BlogCategory/RemoveBlogCategory/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "Blog Kategori  Silindi";
                TempData["mesaj"] = "Blog Kategori başarılı bir şekilde silindi";
                return RedirectToAction("Index", "AdminBlogCategory", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminBlogCategory", new { area = "Admin" });
        }
        [Route("UpdateBlogCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateBlogCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
        
            var responseMessage = await client.GetAsync("https://localhost:7023/api/BlogCategory/GetBlogCategoryById/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateBlogCategoryDto>(jsonData);
                var categoryResponse = await client.GetAsync("https://localhost:7023/api/Category/GetAllCategory");
                if (categoryResponse.IsSuccessStatusCode)
                {
                    var categoryData = await categoryResponse.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryData);
                    List<SelectListItem> categoryValues = (from x in values
                                                           select new SelectListItem
                                                           {
                                                               Selected=x.CategoryId==value.CategoryId,
     
                                                               Value = x.CategoryId.ToString(),
                                                               Text = x.Name
                                                           }).ToList();
                    ViewBag.categoryvalues = categoryValues;
                }

                return View(value);
            }
            return View(new UpdateBlogCategoryDto());

        }
        [Route("UpdateBlogCategory/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateBlogCategory(UpdateBlogCategoryDto BlogCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(BlogCategoryDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7023/api/BlogCategory", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "Hakkımızda kısmı Güncellendi";
                TempData["mesaj"] = "Hakkımızda kısmı başarılı bir şekilde güncellendi";
                return RedirectToAction("Index", "AdminBlogCategory", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminBlogCategory", new { area = "Admin" });
        }
    }
}
