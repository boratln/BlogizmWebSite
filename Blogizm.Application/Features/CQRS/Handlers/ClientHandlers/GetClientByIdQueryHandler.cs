using Blogizm.Application.Features.CQRS.Queries.AboutQueries;
using Blogizm.Application.Features.CQRS.Queries.AuthorQueries;
using Blogizm.Application.Features.CQRS.Queries.ClientQueries;
using Blogizm.Application.Features.CQRS.Results.AuthorResults;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetClientByIdQueryHandler
    {
        private readonly IRepository<Client> _repository;

        public GetClientByIdQueryHandler(IRepository<Client> repository)
        {
            _repository = repository;
        }
        public async Task <GetClientByIdQueryResult> Handle(GetClientByIdQuery query)
        {
            var value = await _repository.GetById(query.Id);
            if (value == null)
            {
                return new GetClientByIdQueryResult();
            }
            return new GetClientByIdQueryResult
            {
               ClientId=query.Id,
               ClientDesc=value.ClientDesc,
               ClientImage=value.ClientImage,
               ClientName=value.ClientName
            };
        }
    }
}
