using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Commands.TagCommands
{
    public class CreateTagCommand
    {
        public string Title { get; set; }
    }
}
