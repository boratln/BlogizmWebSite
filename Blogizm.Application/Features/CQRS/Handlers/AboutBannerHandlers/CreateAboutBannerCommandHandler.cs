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
    public class CreateAboutBannerCommandHandler
    {
        private readonly IRepository<AboutBanner> _repository;

        public CreateAboutBannerCommandHandler(IRepository<AboutBanner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAboutBannerCommand command)
        {
            await _repository.Create(new AboutBanner
            {
                BannerDesc1 = command.BannerDesc1,
                BannerDesc2 = command.BannerDesc2,
                BannerImg1 = command.BannerImg1,
                BannerImg2 = command.BannerImg2,
                BannerTitle1 = command.BannerTitle1,
                BannerTitle2 = command.BannerTitle2,
            });

        }
    }
}
