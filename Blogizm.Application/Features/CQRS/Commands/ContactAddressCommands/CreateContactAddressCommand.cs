using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Commands.ContactAddressCommands
{
    public class CreateContactAddressCommand
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string URL { get; set; }
    }
}
