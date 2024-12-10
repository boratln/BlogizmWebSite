using Blogizm.Application.Dtos.BlogDtos;
using Blogizm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetBlogsWithAuthorAndCategories();
        Task<List<Blog>> GetBlogByCategoryId(int categoryid);
        Task<List<Blog>> GetBlogWithAuthorAndCategoryDesc();
        Task<List<Blog>> GetTop3BlogByCategoryId(int categoryid);
        int GetCountByCategoryId(int categoryid);
        Task<List<BlogAndBlogCategoryCountDto>> BlogAndBlogCategoryCountByCategoryId(int categoryid);
    }
}
