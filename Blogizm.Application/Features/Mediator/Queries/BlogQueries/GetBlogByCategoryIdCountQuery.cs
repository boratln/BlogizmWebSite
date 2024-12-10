using Blogizm.Application.Features.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogByCategoryIdCountQuery:IRequest<GetBlogByCategoryIdCountQueryResult>
    {
        public int CategoryId {  get; set; }

        public GetBlogByCategoryIdCountQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
