using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Queries.AboutQueries
{
    public class GetAboutByIdQuery
    {
        public int Id { get; set; }

        public GetAboutByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
