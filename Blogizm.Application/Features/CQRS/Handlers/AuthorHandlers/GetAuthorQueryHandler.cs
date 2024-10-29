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
    public class GetAuthorQueryHandler
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAuthorQueryResult>> Handle()
        {
            var values=await _repository.GetAll();
            return values.Select(x => new GetAuthorQueryResult
            {
               Surname = x.Surname,
               Name = x.Name,
               Description = x.Description,
               AuthorImage = x.AuthorImage,
               AuthorId = x.AuthorId
            }).ToList();
        }
    }
}
