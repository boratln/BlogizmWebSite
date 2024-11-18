using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Commands.ContactAddressCommands
{
    public class RemoveContactAddressCommand
    {public int Id {  get; set; }

        public RemoveContactAddressCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
