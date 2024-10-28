using Blogizm.Application.Features.CQRS.Results.AboutBannerResults;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Handlers.AboutBannerHandlers
{
    public class GetAboutBannerQueryHandler
    {
        private readonly IRepository<AboutBanner> _repository;

        public GetAboutBannerQueryHandler(IRepository<AboutBanner> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAboutBannerQueryResult>> Handle()
        {
            var values=await _repository.GetAll();
            return values.Select(x => new GetAboutBannerQueryResult
            {
                AboutBannerId = x.AboutBannerId,
                BannerDesc1 = x.BannerDesc1,
                BannerDesc2 = x.BannerDesc2,
                BannerImg1 = x.BannerImg1,
                BannerImg2 = x.BannerImg2,
                BannerTitle1 = x.BannerTitle1,
                BannerTitle2 = x.BannerTitle2,
            }).ToList();
        }
    }
}
