using Blogizm.Application.Features.CQRS.Commands.AboutCommands;
using Blogizm.Application.Features.CQRS.Commands.AuthorCommands;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class RemoveAuthorCommandHandler
    {
        private readonly IRepository<Author> _repository;

        public RemoveAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveAuthorCommand command)
        {
            var value=await _repository.GetById(command.Id);
            await _repository.Remove(value);
        } 
    }
}
