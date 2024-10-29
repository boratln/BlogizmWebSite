using Blogizm.Application.Features.CQRS.Commands.AboutCommands;
using Blogizm.Application.Features.CQRS.Commands.AuthorCommands;
using Blogizm.Application.Features.CQRS.Commands.ClientCommands;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateClientCommandHandler
    {
        private readonly IRepository<Client> _repository;

        public UpdateClientCommandHandler(IRepository<Client> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateClientCommand command)
        {
            var value = await _repository.GetById(command.ClientId);
            value.ClientName= command.ClientName;
            value.ClientDesc= command.ClientDesc;
            value.ClientImage= command.ClientImage;
            await _repository.Update(value);
        }
    }
}
