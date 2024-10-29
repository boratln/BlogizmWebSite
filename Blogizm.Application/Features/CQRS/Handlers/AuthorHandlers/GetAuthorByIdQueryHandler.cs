using Blogizm.Application.Features.CQRS.Queries.AboutQueries;
using Blogizm.Application.Features.CQRS.Queries.AuthorQueries;
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
    public class GetAuthorByIdQueryHandler
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorByIdQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }
        public async Task <GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery query)
        {
            var value = await _repository.GetById(query.Id);
            if (value == null)
            {
                return new GetAuthorByIdQueryResult();
            }
            return new GetAuthorByIdQueryResult
            {
                AuthorId=value.AuthorId,
                AuthorImage=value.AuthorImage,
                Description=value.Description,
                Name=value.Name,
                Surname = value.Surname
            };
        }
    }
}
