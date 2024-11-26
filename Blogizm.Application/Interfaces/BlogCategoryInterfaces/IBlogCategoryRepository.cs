using Blogizm.Application.Dtos.BlogCategoryDtos;
using Blogizm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Interfaces.BlogCategoryInterfaces
{
    public interface IBlogCategoryRepository
    {
        Task<List<BlogCategory>> GetAllBlogWithCategories();
        Task<List<GetAllBlogCategoryWithGroupByDto>> GetAllBlogCategoryWithGroupBy();
        Task<List<BlogCategory>> GetBlogCategoryWithCategoryId(int id);
    }
}
