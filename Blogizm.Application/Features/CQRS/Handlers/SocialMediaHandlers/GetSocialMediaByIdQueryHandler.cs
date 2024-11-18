using Blogizm.Application.Features.CQRS.Queries.SocialMediaQueries;
using Blogizm.Application.Features.CQRS.Results.SocialMediaResults;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }
        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery query)
        {
            var value = await _repository.GetById(query.Id);
            return new GetSocialMediaByIdQueryResult
            {
                Icon = value.Icon,
                SocialMediaId = value.SocialMediaId,
                Title = value.Title,
                URL = value.URL
            };
        }
    }
}
