using Blogizm.Application.Features.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetTop3BlogByCategoryIdQuery:IRequest<List<GetTop3BlogByCategoryIdQueryResult>>
    {
        public int CategoryId {  get; set; }

        public GetTop3BlogByCategoryIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
