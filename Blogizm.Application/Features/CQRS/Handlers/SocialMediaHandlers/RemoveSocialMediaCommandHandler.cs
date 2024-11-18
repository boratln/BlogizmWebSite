using Blogizm.Application.Features.CQRS.Commands.SocialMediaCommands;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class RemoveSocialMediaCommandHandler
    {
        private readonly IRepository<SocialMedia> _repository;

        public RemoveSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveSocialMediaCommand command)
        {
            var value = await _repository.GetById(command.Id);
            await _repository.Remove(value);
        }
    }
}
