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
    public class UpdateSocialMediaCommandHandler
    {
        private readonly IRepository<SocialMedia> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateSocialMediaCommand command)
        {
            var value = await _repository.GetById(command.SocialMediaId);
            value.Title = command.Title;
            value.Icon=command.Icon;
            await _repository.Update(value);
        }
    }
}
