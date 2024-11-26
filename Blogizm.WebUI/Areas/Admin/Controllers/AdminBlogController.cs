using Blogizm.Dtos.AuthorDtos;
using Blogizm.Dtos.BlogCategoryDtos;
using Blogizm.Dtos.BlogDtos;
using Blogizm.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Blogizm.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminBlog")]
    public class AdminBlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7023/api/Blog/GetBlogsWithAuthorAndCategories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("CreateBlog")]
        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            //category idsi seçilecek
            //blog category oto gelecek
            var client=_httpClientFactory.CreateClient();
            var categoryResponse = await client.GetAsync("https://localhost:7023/api/Category/GetAllCategory");
            if (categoryResponse.IsSuccessStatusCode)
            {
                var categoryJsonData = await categoryResponse.Content.ReadAsStringAsync();
                var categoryValues = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJsonData);
                List<SelectListItem> categoryvalues2 = (from ctg in categoryValues
                                                        select new SelectListItem
                                                        {
                                                            Text = ctg.Name,
                                                            Value = ctg.CategoryId.ToString()
                                                        }).ToList();
                ViewBag.CategoryValues = categoryvalues2;
            }
            var client2 = _httpClientFactory.CreateClient();
            var blogCategoryResponse = await client2.GetAsync("https://localhost:7023/api/BlogCategory");
            if (blogCategoryResponse.IsSuccessStatusCode)
            {
                var blogCategoryJsonData = await blogCategoryResponse.Content.ReadAsStringAsync();
                var blogCategoryValues = JsonConvert.DeserializeObject<List<ResultBlogCategoryDto>>(blogCategoryJsonData);
                List<SelectListItem> blogCategoryValues2 = (from blogctg in blogCategoryValues
                                                            select new SelectListItem
                                                            {
                                                                Text = blogctg.BlogCategoryName,
                                                                Value = blogctg.BlogCategoryId.ToString()
                                                            }).ToList();
                ViewBag.BlogCategoryValues = blogCategoryValues2;
            }

            var client3 = _httpClientFactory.CreateClient();
            var authorResponse = await client3.GetAsync("https://localhost:7023/api/Author/GetAllAuthor");
            if (authorResponse.IsSuccessStatusCode)
            {
                var authorJsonData = await authorResponse.Content.ReadAsStringAsync();
                var authorValues = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(authorJsonData);
                List<SelectListItem> authorValues2 = (from author in authorValues
                                                      select new SelectListItem
                                                      {
                                                          Text = author.Name+" "+author.Surname,
                                                          Value = author.AuthorId.ToString()
                                                      }).ToList();
                ViewBag.AuthorValues = authorValues2;
            }
            return View();
        }
        [Route("CreateBlog")]
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto BlogDto)
        {
            BlogDto.CreatedDate = DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(BlogDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7023/api/Blog", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "Blog Eklendi";
                TempData["mesaj"] = "Blog başarılı bir şekilde eklendi";
                return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });

        }
        [Route("RemoveBlog/{id}")]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7023/api/Blog/DeleteBlog/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "Blog Silindi";
                TempData["mesaj"] = "Blog başarılı bir şekilde silindi";
                return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
        }
        [Route("UpdateBlog/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var categoryResponse = await client.GetAsync("https://localhost:7023/api/Category/GetAllCategory");
            if (categoryResponse.IsSuccessStatusCode)
            {
                var categoryJsonData = await categoryResponse.Content.ReadAsStringAsync();
                var categoryValues = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJsonData);
                List<SelectListItem> categoryvalues2 = (from ctg in categoryValues
                                                        select new SelectListItem
                                                        {
                                                            Text = ctg.Name,
                                                            Value = ctg.CategoryId.ToString()
                                                        }).ToList();
                ViewBag.CategoryValues = categoryvalues2;
            }
            var client2 = _httpClientFactory.CreateClient();
            var blogCategoryResponse = await client2.GetAsync("https://localhost:7023/api/BlogCategory");
            if (blogCategoryResponse.IsSuccessStatusCode)
            {
                var blogCategoryJsonData = await blogCategoryResponse.Content.ReadAsStringAsync();
                var blogCategoryValues = JsonConvert.DeserializeObject<List<ResultBlogCategoryDto>>(blogCategoryJsonData);
                List<SelectListItem> blogCategoryValues2 = (from blogctg in blogCategoryValues
                                                            select new SelectListItem
                                                            {
                                                                Text = blogctg.BlogCategoryName,
                                                                Value = blogctg.BlogCategoryId.ToString()
                                                            }).ToList();
                ViewBag.BlogCategoryValues = blogCategoryValues2;
            }

            var client3 = _httpClientFactory.CreateClient();
            var authorResponse = await client3.GetAsync("https://localhost:7023/api/Author/GetAllAuthor");
            if (authorResponse.IsSuccessStatusCode)
            {
                var authorJsonData = await authorResponse.Content.ReadAsStringAsync();
                var authorValues = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(authorJsonData);
                List<SelectListItem> authorValues2 = (from author in authorValues
                                                      select new SelectListItem
                                                      {
                                                          Text = author.Name + " " + author.Surname,
                                                          Value = author.AuthorId.ToString()
                                                      }).ToList();
                ViewBag.AuthorValues = authorValues2;
            }
            var client4=_httpClientFactory.CreateClient();

            var responseMessage = await client4.GetAsync("https://localhost:7023/api/Blog/GetBlogById/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateBlogDto>(jsonData);


                return View(value);
            }
            return View(new UpdateBlogDto());

        }
        [Route("UpdateBlog/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto BlogDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(BlogDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7023/api/Blog/UpdateBlog", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TempData["baslik"] = "Blog Güncellendi";
                TempData["mesaj"] = "Blog başarılı bir şekilde güncellendi";
                return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
        }
    }
}
