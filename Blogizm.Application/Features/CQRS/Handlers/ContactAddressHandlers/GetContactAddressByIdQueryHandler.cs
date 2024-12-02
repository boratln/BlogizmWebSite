using Blogizm.Application.Features.CQRS.Queries.ContactAddressQueries;
using Blogizm.Application.Features.CQRS.Results.ContactAddressResults;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Handlers.ContactAddressHandlers
{
    public class GetContactAddressByIdQueryHandler
    {
        private readonly IRepository<ContactAddress> _repository;

        public GetContactAddressByIdQueryHandler(IRepository<ContactAddress> repository)
        {
            _repository = repository;
        }
        public async Task<GetContactAddressByIdQueryResult> Handle(GetContactAddressByIdQuery query)
        {
            var value = await _repository.GetById(query.Id);
            return new GetContactAddressByIdQueryResult
            {
                ContactAddressId = value.ContactAddressId,
                Icon = value.Icon,
                Title = value.Title,
                URL = value.URL,
                Description=value.Description
            };
        }
    }
}
