using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Commands.ContactAddressCommands
{
    public class UpdateContactAddressCommand
    {
        public int ContactAddressId { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }

        public string URL { get; set; }
    }
}
