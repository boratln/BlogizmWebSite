using Blogizm.Application.Features.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogByCategoryIdQuery:IRequest<List<GetBlogByCategoryIdQueryResult>>
    {
        public int Id { get; set; }

        public GetBlogByCategoryIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
