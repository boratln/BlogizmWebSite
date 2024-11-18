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
    public class CreateSocialMediaCommandHandler
    {
        private readonly IRepository<SocialMedia> _repository;

        public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateSocialMediaCommand command)
        {
            await _repository.Create(new SocialMedia
            {
                Icon = command.Icon,
                Title = command.Title,
                URL = command.URL,
            });
        }
    }
}
