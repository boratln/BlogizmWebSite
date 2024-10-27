using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Commands
{
    public class CreateAboutCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
