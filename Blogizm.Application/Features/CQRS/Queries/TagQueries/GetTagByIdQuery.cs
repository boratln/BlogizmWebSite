using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Queries.TagQueries
{
    public class GetTagByIdQuery
    {
        public int Id { get; set; }

        public GetTagByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
