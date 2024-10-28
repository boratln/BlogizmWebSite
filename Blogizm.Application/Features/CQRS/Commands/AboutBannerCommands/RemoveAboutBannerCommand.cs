using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Commands.AboutBannerCommands
{
    public class RemoveAboutBannerCommand
    {
        public int Id { get; set; }

        public RemoveAboutBannerCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
