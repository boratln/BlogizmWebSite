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
    public class UpdateBlogCategoryCommandHandler : IRequestHandler<UpdateBlogCategoryCommand>
    {
        private readonly IRepository<BlogCategory> _blogCategoryRepository;

        public UpdateBlogCategoryCommandHandler(IRepository<BlogCategory> blogCategoryRepository)
        {
            _blogCategoryRepository = blogCategoryRepository;
        }

        public async Task Handle(UpdateBlogCategoryCommand request, CancellationToken cancellationToken)
        {
            var value = await _blogCategoryRepository.GetById(request.BlogCategoryId);
            value.CategoryId = request.CategoryId;
            value.Name = request.Name;
            await _blogCategoryRepository.Update(value);
        }
    }
}
