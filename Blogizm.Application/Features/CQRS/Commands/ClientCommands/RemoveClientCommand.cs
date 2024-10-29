using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Commands.ClientCommands
{
    public class RemoveClientCommand
    {
        public int Id { get; set; }

        public RemoveClientCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
