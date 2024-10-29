using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Queries.ClientQueries
{
    public class GetClientByIdQuery
    {
        public int Id { get; set; }

        public GetClientByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
