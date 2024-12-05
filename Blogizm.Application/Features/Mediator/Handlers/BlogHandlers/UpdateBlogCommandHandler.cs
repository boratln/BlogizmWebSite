using Blogizm.Application.Features.Mediator.Commands.BlogCommands;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _blogRepository;

        public UpdateBlogCommandHandler(IRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
           var value=await _blogRepository.GetById(request.BlogId);
            value.Description = request.Description;
            value.BlogCategoryId = request.BlogCategoryId;
            value.AuthorId = request.AuthorId;
            value.CoverImageUrl = request.CoverImageUrl;
            value.BlogImage1 = request.BlogImage1;
            value.BlogImage2 = request.BlogImage2;
            value.BlogImage3 = request.BlogImage3;
            value.VideoUrl = request.VideoUrl;
            await _blogRepository.Update(value);
        }
    }
}
