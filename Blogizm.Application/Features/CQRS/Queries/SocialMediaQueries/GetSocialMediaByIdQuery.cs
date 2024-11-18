using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Queries.SocialMediaQueries
{
    public class GetSocialMediaByIdQuery
    {
        public int Id { get; set; }

        public GetSocialMediaByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
