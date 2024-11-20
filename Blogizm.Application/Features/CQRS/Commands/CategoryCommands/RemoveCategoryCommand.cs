using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Commands.CategoryCommands
{
    public class RemoveCategoryCommand
    {
       public int Id {  get; set; }

        public RemoveCategoryCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
