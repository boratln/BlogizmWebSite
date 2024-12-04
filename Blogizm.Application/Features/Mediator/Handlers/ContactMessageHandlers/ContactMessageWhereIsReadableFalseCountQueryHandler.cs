using Blogizm.Application.Features.Mediator.Queries.ContactMessageQueries;
using Blogizm.Application.Features.Mediator.Results.ContactMessageResults;
using Blogizm.Application.Interfaces.ContactMessageInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Handlers.ContactMessageHandlers
{
    public class ContactMessageWhereIsReadableFalseCountQueryHandler : IRequestHandler<ContactMessageWhereIsReadableFalseCountQuery, ContactMessageWhereIsReadableFalseCountQueryResult>
    {
        private readonly IContactMessageRepository _contactMessageRepository;

        public ContactMessageWhereIsReadableFalseCountQueryHandler(IContactMessageRepository contactMessageRepository)
        {
            _contactMessageRepository = contactMessageRepository;
        }

        public async Task <ContactMessageWhereIsReadableFalseCountQueryResult> Handle(ContactMessageWhereIsReadableFalseCountQuery request, CancellationToken cancellationToken)
        {
            var count =   _contactMessageRepository.ContactMessageWhereIsReadableFalseCount();
            return new ContactMessageWhereIsReadableFalseCountQueryResult
            {
                MessageCount = count
            };
        }

      
    }
}
