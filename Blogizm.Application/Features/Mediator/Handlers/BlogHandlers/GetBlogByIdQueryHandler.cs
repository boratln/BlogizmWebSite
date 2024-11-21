using Blogizm.Application.Features.Mediator.Queries.BlogQueries;
using Blogizm.Application.Features.Mediator.Results.BlogResults;
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
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _blogRepository;

        public GetBlogByIdQueryHandler(IRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _blogRepository.GetById(request.Id);
            return new GetBlogByIdQueryResult
            {
                AuthorId = value.AuthorId,
                BlogCategoryId = value.BlogCategoryId,
                BlogId = value.BlogId,
                BlogImage1 = value.BlogImage1,
                BlogImage2 = value.BlogImage2,
                BlogImage3 = value.BlogImage3,
                CoverImageUrl = value.CoverImageUrl,
                CreatedDate = value.CreatedDate,
                Description = value.Description,
                Title = value.Title
            };
        }
    }
}
