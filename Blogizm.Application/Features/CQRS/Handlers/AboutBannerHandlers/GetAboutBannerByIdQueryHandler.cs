using Blogizm.Application.Features.CQRS.Queries.AboutBannerQueries;
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
    public class GetAboutBannerByIdQueryHandler
    {
        private readonly IRepository<AboutBanner> _repository;

        public GetAboutBannerByIdQueryHandler(IRepository<AboutBanner> repository)
        {
            _repository = repository;
        }
        public async Task<GetAboutBannerByIdQueryResult> Handle(GetAboutBannerByIdQuery query)
        {
            var value = await _repository.GetById(query.Id);
            return new GetAboutBannerByIdQueryResult
            {
                AboutBannerId = query.Id,
                BannerDesc1 = value.BannerDesc1,
                BannerDesc2 = value.BannerDesc2,
                BannerImg1 = value.BannerImg1,
                BannerImg2 = value.BannerImg2,
                BannerTitle1 = value.BannerTitle1,
                BannerTitle2 = value.BannerTitle2,

            };
        }
    }
}
