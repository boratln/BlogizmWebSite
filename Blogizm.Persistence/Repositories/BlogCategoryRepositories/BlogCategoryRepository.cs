using Blogizm.Application.Dtos.BlogCategoryDtos;
using Blogizm.Application.Interfaces.BlogCategoryInterfaces;
using Blogizm.Domain.Entities;
using Blogizm.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Persistence.Repositories.BlogCategoryRepositories
{
    public class BlogCategoryRepository : IBlogCategoryRepository
    {
        private readonly BlogContext _blogContext;

        public BlogCategoryRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<List<GetAllBlogCategoryWithGroupByDto>> GetAllBlogCategoryWithGroupBy()
        {

            var query = await (from blogCategory in _blogContext.BlogCategories
                         join category in _blogContext.Categories
                         on blogCategory.CategoryId equals category.CategoryId into groupedCategories
                         from category in groupedCategories.DefaultIfEmpty()
                         group new { blogCategory, category } by new
                         {
                             blogCategory.BlogCategoryId,
                             category.CategoryId,
                             BlogCategoryName=blogCategory.Name,
                             CategoryName=category.Name
                         } into grouped
                         orderby grouped.Key.CategoryId
                         select new GetAllBlogCategoryWithGroupByDto
                         {
                             BlogCategoryId = grouped.Key.BlogCategoryId,
                             CategoryId = grouped.Key.CategoryId,
                             BlogCategoryName = grouped.Key.BlogCategoryName,
                             CategoryName=grouped.Key.CategoryName,
                             
                         }).ToListAsync();

            
            return query;
            
        }

        public async Task<List<BlogCategory>> GetAllBlogWithCategories()
        {
            var values = await _blogContext.BlogCategories.Include(x => x.Category).ToListAsync();
            return values;
        }

        public async Task<List<BlogCategory>> GetBlogCategoryWithCategoryId(int id)
        {
           var values=await _blogContext.BlogCategories.Include(x=>x.Category).Where(x=>x.CategoryId == id).ToListAsync();
            return values;
        }
    }
}
