using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Results.AuthorResults
{
    public class GetClientByIdQueryResult
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientDesc { get; set; }
        public string ClientImage { get; set; }
    }
}
