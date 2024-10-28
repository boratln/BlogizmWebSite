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
    public class UpdateAboutBannerCommandHandler
    {
        private readonly IRepository<AboutBanner> _repository;

        public UpdateAboutBannerCommandHandler(IRepository<AboutBanner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAboutBannerCommand command)
        {
            var value = await _repository.GetById(command.AboutBannerId);
            value.BannerImg1 = command.BannerImg1;
            value.BannerImg2=command.BannerImg2;
            value.BannerDesc2 = command.BannerDesc2;
            value.BannerDesc1 = command.BannerDesc1;
            await _repository.Update(value);
        }
    }
}
