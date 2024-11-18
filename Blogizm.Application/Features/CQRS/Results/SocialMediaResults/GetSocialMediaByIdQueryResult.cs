using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Results.SocialMediaResults
{
    public class GetSocialMediaByIdQueryResult
    {
        public int SocialMediaId { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string URL { get; set; }
    }
}
