using Blogizm.Application.Features.Mediator.Results.BlogCategoryResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Queries.BlogCategoryQueries
{
    public class GetAllBlogCategoryWithGroupByQuery:IRequest<List<GetAllBlogCategoryWithGroupByQueryResult>>
    {
    }
}
