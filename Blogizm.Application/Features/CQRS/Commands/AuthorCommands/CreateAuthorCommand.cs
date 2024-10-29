using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Commands.AuthorCommands
{
    public class CreateAuthorCommand
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string AuthorImage { get; set; }
    }
}
