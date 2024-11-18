using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Commands.TagCommands
{
    public class RemoveTagCommand
    {
        public int Id { get; set; }

        public RemoveTagCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
