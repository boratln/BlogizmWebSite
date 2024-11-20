using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Commands.BlogCategoryCommands
{
    public class CreateBlogCategoryCommand:IRequest
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
