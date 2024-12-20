﻿using Blogizm.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blogizm.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultCarouselComponentPartial:ViewComponent
        
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultCarouselComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7023/api/Blog/GetBlogWithAuthorAndCategoryDesc");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<BlogWithAuthorAndCategoryDescDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
