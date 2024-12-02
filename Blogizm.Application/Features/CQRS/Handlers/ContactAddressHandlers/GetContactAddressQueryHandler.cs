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
    public class GetContactAddressQueryHandler
    {
        private readonly IRepository<ContactAddress> _repository;

        public GetContactAddressQueryHandler(IRepository<ContactAddress> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetContactAddressQueryResult>> Handle()
        {
            var values= await _repository.GetAll();
            return values.Select(x => new GetContactAddressQueryResult
            {
                ContactAddressId = x.ContactAddressId,
                Icon = x.Icon,
                Title = x.Title,
                URL = x.URL,
                Description=x.Description
            }).ToList();
        }
    }
}
