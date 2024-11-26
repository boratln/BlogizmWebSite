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

        public async Task<List<Blog>> GetBlogByCategoryId(int categoryid)
        {
            var values= await _blogContext.Blogs.Include(x=>x.BlogCategory).ThenInclude(x=>x.Category).Where(x=>x.BlogCategory.CategoryId == categoryid).ToListAsync();
            return values;
        }

        public async Task<List<Blog>> GetBlogsWithAuthorAndCategories()
        {
            var values = await _blogContext.Blogs.Include(x => x.Author).Include(x => x.BlogCategory).ThenInclude(x=>x.Category).ToListAsync();
            return values;
        }
    }
}
