using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Commands.AuthorCommands
{
    public class RemoveAuthorCommand
    {
        public int Id { get; set; }

        public RemoveAuthorCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
