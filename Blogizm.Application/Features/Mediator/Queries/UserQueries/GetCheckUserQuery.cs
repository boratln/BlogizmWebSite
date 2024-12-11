using Blogizm.Application.Features.Mediator.Results.UserResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Queries.UserQueries
{
    public class GetCheckUserQuery:IRequest<GetCheckUserQueryResult>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
