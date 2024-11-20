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
    public class CreateBlogCategoryCommandHandler : IRequestHandler<CreateBlogCategoryCommand>
    {
        private readonly IRepository<BlogCategory> _blogCategoryRepository;

        public CreateBlogCategoryCommandHandler(IRepository<BlogCategory> blogCategoryRepository)
        {
            _blogCategoryRepository = blogCategoryRepository;
        }

        public async Task Handle(CreateBlogCategoryCommand request, CancellationToken cancellationToken)
        {
            await _blogCategoryRepository.Create(new BlogCategory
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
            });
        }
    }
}
