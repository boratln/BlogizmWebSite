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
    public class UpdateAuthorCommandHandler
    {
        private readonly IRepository<Author> _repository;

        public UpdateAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAuthorCommand command)
        {
            var value = await _repository.GetById(command.AuthorId);
            value.Name= command.Name;
            value.Surname= command.Surname;
            value.AuthorImage= command.AuthorImage;
            value.Description= command.Description;
            await _repository.Update(value);
        }
    }
}
