using Blogizm.Application.Features.CQRS.Commands.TagCommands;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Handlers.TagHandlers
{
    public class UpdateTagCommandHandler
    {
        private readonly IRepository<Tag> _tagRepository;

        public UpdateTagCommandHandler(IRepository<Tag> tagRepository)
        {
            _tagRepository = tagRepository;

        }
        public async Task Handle(UpdateTagCommand command)
        {
            var value = await _tagRepository.GetById(command.TagId);
            value.Title = command.Title;
            await _tagRepository.Update(value);
        }
    }
}
