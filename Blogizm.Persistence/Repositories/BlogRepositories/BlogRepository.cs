using Blogizm.Application.Dtos.BlogDtos;
using Blogizm.Application.Interfaces.BlogInterfaces;
using Blogizm.Domain.Entities;
using Blogizm.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _blogContext;

        public BlogRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<List<BlogAndBlogCategoryCountDto>> BlogAndBlogCategoryCountByCategoryId(int categoryid)
        {
            var result = await (
          from blogCategory in _blogContext.BlogCategories
          join blog in _blogContext.Blogs
              on blogCategory.BlogCategoryId equals blog.BlogCategoryId into joinedBlogs
          from blog in joinedBlogs.DefaultIfEmpty()
          where blogCategory.CategoryId == categoryid
          group blog by new { blogCategory.Name, blogCategory.CategoryId } into grouped
          select new BlogAndBlogCategoryCountDto
          {
              BlogCount = grouped.Count(g => g != null),
              BlogCategoryName = grouped.Key.Name
          }
      )
.OrderBy(dto => dto.BlogCount > 0 ? 0 : 1)  // BlogCount > 0 olanlar önce gelir
      .ThenBy(dto => dto.BlogCategoryName)        
      .ToListAsync();
            return result;

        }

        public async Task<List<Blog>> GetBlogByCategoryId(int categoryid)
        {
            var values= await _blogContext.Blogs.Include(x=>x.BlogCategory).ThenInclude(x=>x.Category).Include(x=>x.Author).Where(x=>x.BlogCategory.CategoryId == categoryid).ToListAsync();
            return values;
        }

        public async Task<List<Blog>> GetBlogsWithAuthorAndCategories()
        {
            var values = await _blogContext.Blogs.Include(x => x.Author).Include(x => x.BlogCategory).ThenInclude(x=>x.Category).ToListAsync();
            return values;
        }

        public async Task<List<Blog>> GetBlogWithAuthorAndCategoryDesc()
        {
            var values = await _blogContext.Blogs.Include(x => x.Author).Include(x => x.BlogCategory).ThenInclude(x => x.Category).OrderByDescending(x => x.BlogId).Take(5).ToListAsync();
            return values;
        }

        public int GetCountByCategoryId(int categoryid)
        {
            var count = _blogContext.Blogs.Include(x => x.BlogCategory).ThenInclude(x => x.Category).Where(x => x.BlogCategory.CategoryId == categoryid).Count();
            return count;
        }

        public async Task<List<Blog>> GetTop3BlogByCategoryId(int categoryid)
        {
            var values = await _blogContext.Blogs.Include(x => x.Author).Include(x => x.BlogCategory).ThenInclude(x => x.Category).Where(x=>x.BlogCategory.CategoryId==categoryid).Take(3).OrderByDescending(x => x.BlogId).ToListAsync();
            return values;
        }
    }
}
