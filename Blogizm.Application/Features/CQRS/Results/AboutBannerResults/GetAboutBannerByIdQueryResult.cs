using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Results.AboutBannerResults
{
    public class GetAboutBannerByIdQueryResult
    {
        public int AboutBannerId { get; set; }
        public string BannerTitle1 { get; set; }
        public string BannerDesc1 { get; set; }
        public string BannerImg1 { get; set; }
        public string BannerTitle2 { get; set; }
        public string BannerDesc2 { get; set; }
        public string BannerImg2 { get; set; }
    }
}
