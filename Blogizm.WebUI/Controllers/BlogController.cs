using Blogizm.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blogizm.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        
        public async Task<IActionResult> Index(int id, int page = 1, int itemsPerPage = 5)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7023/api/Blog/GetBlogByCategoryId/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
   
                var values = JsonConvert.DeserializeObject<List<ResultBlogDto>>(jsonData);
                var client2 = _httpClientFactory.CreateClient();
                var BlogCountResponse = await client2.GetAsync("https://localhost:7023/api/Blog/GetBlogByCategoryIdCount/" + id);
                if (BlogCountResponse.IsSuccessStatusCode)
                {
                    var BlogCountjsonData = await BlogCountResponse.Content.ReadAsStringAsync();
                    var count = JsonConvert.DeserializeObject<ResultBlogCountDto>(BlogCountjsonData);
                    var pagination = new BlogPaginationDto
                    {
                        TotalItems = count.BlogCount,
                        ItemsPerPage = itemsPerPage,
                        CurrentPage = page
                    };
                    var pagedValues = values
          .Skip((page - 1) * itemsPerPage)
          .Take(itemsPerPage)
          .ToList();
                    ViewBag.Pagination = pagination;
                    ViewBag.count = count.BlogCount;
                    ViewBag.id = id;
                    return View(pagedValues);
                }
        
            }

        
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            //Yorum eklense
            return RedirectToAction("Index", "Blog");
        }
        public async Task<IActionResult> BlogDetail(int id,string param)
        {
            ViewBag.id = id;
            ViewBag.categoryid=int.Parse(param);
            return View();
        }
        
    }
}
