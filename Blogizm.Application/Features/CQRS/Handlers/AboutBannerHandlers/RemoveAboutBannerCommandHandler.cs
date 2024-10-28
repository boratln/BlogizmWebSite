using Blogizm.Application.Features.CQRS.Commands.AboutBannerCommands;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Handlers.AboutBannerHandlers
{
    public class RemoveAboutBannerCommandHandler
    {
        private readonly IRepository<AboutBanner> _repository;

        public RemoveAboutBannerCommandHandler(IRepository<AboutBanner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveAboutBannerCommand command)
        {
            var value = await _repository.GetById(command.Id);
            await _repository.Remove(value);
        }
    }
}
