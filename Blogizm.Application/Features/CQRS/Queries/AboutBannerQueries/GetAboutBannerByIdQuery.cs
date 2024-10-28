using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Queries.AboutBannerQueries
{
    public class GetAboutBannerByIdQuery
    {
        public int Id { get; set; }

        public GetAboutBannerByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
