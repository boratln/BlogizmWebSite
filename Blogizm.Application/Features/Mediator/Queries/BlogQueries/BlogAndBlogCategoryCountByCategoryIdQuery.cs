using Blogizm.Application.Features.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Queries.BlogQueries
{
    public class BlogAndBlogCategoryCountByCategoryIdQuery:IRequest<List<BlogAndBlogCategoryCountByCategoryIdQueryResult>>
    {
        public int CategoryId { get; set; }

        public BlogAndBlogCategoryCountByCategoryIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
