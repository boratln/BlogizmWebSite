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
    public class UpdateContactAddressCommandHandler
    {
        private readonly IRepository<ContactAddress> _repository;

        public UpdateContactAddressCommandHandler(IRepository<ContactAddress> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateContactAddressCommand command)
        {
            var value = await _repository.GetById(command.ContactAddressId);
            value.Title = command.Title;
            value.URL= command.URL;
            value.Icon= command.Icon;
            value.Description = command.Description;
            await _repository.Update(value);
        }
    }
}
