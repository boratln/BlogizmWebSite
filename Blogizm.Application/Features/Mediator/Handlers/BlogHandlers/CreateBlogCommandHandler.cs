using Blogizm.Application.Features.Mediator.Commands;
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
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _blogRepository;

        public CreateBlogCommandHandler(IRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            await _blogRepository.Create(new Blog
            {
                AuthorId = request.AuthorId,
                BlogCategoryId = request.BlogCategoryId,
                BlogImage1 = request.BlogImage1,
                BlogImage2 = request.BlogImage2,
                BlogImage3 = request.BlogImage3,
                CoverImageUrl = request.CoverImageUrl,
                CreatedDate = request.CreatedDate,
                Description = request.Description,
                SubDescription = request.SubDescription,
                Title = request.Title,
                VideoUrl = request.VideoUrl,
            });
        }
    }
}
