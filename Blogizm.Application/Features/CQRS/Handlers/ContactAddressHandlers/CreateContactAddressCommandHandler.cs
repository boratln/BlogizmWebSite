using Blogizm.Application.Features.CQRS.Commands.ContactAddressCommands;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Handlers.ContactAddressHandlers
{
    public class CreateContactAddressCommandHandler
    {
        private readonly IRepository<ContactAddress> _repository;

        public CreateContactAddressCommandHandler(IRepository<ContactAddress> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateContactAddressCommand command)
        {
            await _repository.Create(new ContactAddress
            {
                Icon = command.Icon,
                Title = command.Title,
                URL = command.URL,
            });
        }
    }
}
