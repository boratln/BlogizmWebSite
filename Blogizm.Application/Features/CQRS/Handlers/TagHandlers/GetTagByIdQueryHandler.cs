using Blogizm.Application.Features.CQRS.Queries.TagQueries;
using Blogizm.Application.Features.CQRS.Results.TagResults;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Handlers.TagHandlers
{
    public class GetTagByIdQueryHandler
    {
        private readonly IRepository<Tag> _tagRepository;

        public GetTagByIdQueryHandler(IRepository<Tag> tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task<GetTagByIdQueryResult>Handle(GetTagByIdQuery query)
        {
            var value = await _tagRepository.GetById(query.Id);
            return new GetTagByIdQueryResult
            {
                TagId = query.Id,
                Title = value.Title,
            };
        }
    }
}
