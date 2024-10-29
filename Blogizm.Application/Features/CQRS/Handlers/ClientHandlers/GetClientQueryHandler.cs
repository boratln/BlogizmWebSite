using Blogizm.Application.Features.CQRS.Results.AboutResults;
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
    public class GetClientQueryHandler
    {
        private readonly IRepository<Client> _repository;

        public GetClientQueryHandler(IRepository<Client> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetClientQueryResult>> Handle()
        {
            var values=await _repository.GetAll();
            return values.Select(x => new GetClientQueryResult
            {
               ClientId=x.ClientId,
               ClientName=x.ClientName,
               ClientImage=x.ClientImage,
               ClientDesc = x.ClientDesc
            }).ToList();
        }
    }
}
