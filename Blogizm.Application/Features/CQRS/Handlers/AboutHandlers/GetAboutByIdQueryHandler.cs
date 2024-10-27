using Blogizm.Application.Features.CQRS.Queries.AboutQueries;
using Blogizm.Application.Features.CQRS.Results.AboutResults;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task <GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var value = await _repository.GetById(query.Id);
            return new GetAboutByIdQueryResult
            {
                AboutId = value.AboutId,
                Description = value.Description,
                Title = value.Title,
            };
        }
    }
}
