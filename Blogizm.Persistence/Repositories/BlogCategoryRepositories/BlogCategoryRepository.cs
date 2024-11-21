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

        public async Task<List<BlogCategory>> GetAllBlogWithCategories()
        {
            var values = await _blogContext.BlogCategories.Include(x => x.Category).ToListAsync();
            return values;
        }
    }
}
