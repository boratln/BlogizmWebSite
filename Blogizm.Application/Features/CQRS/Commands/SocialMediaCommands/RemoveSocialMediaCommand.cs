using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Commands.SocialMediaCommands
{
    public class RemoveSocialMediaCommand
    {
        public int Id { get; set; }

        public RemoveSocialMediaCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
