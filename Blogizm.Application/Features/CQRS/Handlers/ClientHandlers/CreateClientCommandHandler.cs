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
    public class CreateClientCommandHandler
    {
        private readonly IRepository<Client> _repository;

        public CreateClientCommandHandler(IRepository<Client> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateClientCommand command)
        {
            await _repository.Create(new Client
            {
             ClientDesc = command.ClientDesc,
             ClientImage= command.ClientImage,
             ClientName= command.ClientName,

            });
        }
    }
}
