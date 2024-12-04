using Blogizm.Application.Features.Mediator.Results.ContactMessageResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Queries.ContactMessageQueries
{
    public class GetContactMessageWhereIsReadableFalseQuery:IRequest<List<GetContactMessageWhereIsReadableFalseQueryResult>>
    {
    }
}
