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
    public class RemoveContactAddressCommandHandlerr
    {
        private readonly IRepository<ContactAddress> _repository;

        public RemoveContactAddressCommandHandlerr(IRepository<ContactAddress> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveContactAddressCommand command)
        {
            var value = await _repository.GetById(command.Id);
            await _repository.Remove(value);
        }
    }
}
