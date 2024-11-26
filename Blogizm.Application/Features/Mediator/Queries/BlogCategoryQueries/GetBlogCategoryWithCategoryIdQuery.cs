using Blogizm.Application.Features.Mediator.Results.BlogCategoryResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Queries.BlogCategoryQueries
{
    public class GetBlogCategoryWithCategoryIdQuery:IRequest<List<GetBlogCategoryWithCategoryIdQueryResult>>
    {
        public int Id { get; set; }

        public GetBlogCategoryWithCategoryIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
