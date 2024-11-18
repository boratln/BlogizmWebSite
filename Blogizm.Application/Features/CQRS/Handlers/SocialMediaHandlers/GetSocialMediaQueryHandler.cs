using Blogizm.Application.Features.CQRS.Results.SocialMediaResults;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetSocialMediaQueryResult>> Handle()
        {
            var values = await _repository.GetAll();
            return values.Select(x => new GetSocialMediaQueryResult
            {
                Icon = x.Icon,
                SocialMediaId = x.SocialMediaId,
                Title = x.Title,
                URL = x.URL,
            }).ToList();
        }
    }
}
