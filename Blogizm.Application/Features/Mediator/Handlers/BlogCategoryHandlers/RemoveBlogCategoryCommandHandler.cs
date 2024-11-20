using Blogizm.Application.Features.Mediator.Commands.BlogCategoryCommands;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Handlers.BlogCategoryHandlers
{
    public class RemoveBlogCategoryCommandHandler : IRequestHandler<RemoveBlogCategoryCommand>
    {
        private readonly IRepository<BlogCategory> _blogCategoryrepository;

        public RemoveBlogCategoryCommandHandler(IRepository<BlogCategory> blogCategoryrepository)
        {
            _blogCategoryrepository = blogCategoryrepository;
        }

        public async Task Handle(RemoveBlogCategoryCommand request, CancellationToken cancellationToken)
        {
            var value = await _blogCategoryrepository.GetById(request.Id);
            await _blogCategoryrepository.Remove(value);
        }
    }
}
