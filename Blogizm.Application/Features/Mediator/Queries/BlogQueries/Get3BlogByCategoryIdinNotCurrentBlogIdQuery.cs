using Blogizm.Application.Features.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Queries.BlogQueries
{
    public class Get3BlogByCategoryIdinNotCurrentBlogIdQuery:IRequest<List<Get3BlogByCategoryIdinNotCurrentBlogIdQueryResult>>
    {
        public int BlogId { get; set; }
        public int CategoryId { get; set; }

        public Get3BlogByCategoryIdinNotCurrentBlogIdQuery(int categoryId, int blogId)
        {
            CategoryId = categoryId;
            BlogId = blogId;
        }
    }
}
