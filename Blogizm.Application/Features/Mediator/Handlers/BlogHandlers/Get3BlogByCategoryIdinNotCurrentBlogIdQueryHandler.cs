using Blogizm.Application.Features.Mediator.Queries.BlogQueries;
using Blogizm.Application.Features.Mediator.Results.BlogResults;
using Blogizm.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class Get3BlogByCategoryIdinNotCurrentBlogIdQueryHandler : IRequestHandler<Get3BlogByCategoryIdinNotCurrentBlogIdQuery, List<Get3BlogByCategoryIdinNotCurrentBlogIdQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public Get3BlogByCategoryIdinNotCurrentBlogIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<Get3BlogByCategoryIdinNotCurrentBlogIdQueryResult>> Handle(Get3BlogByCategoryIdinNotCurrentBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.Get3BlogByCategoryIdinNotCurrentBlogId(request.CategoryId, request.BlogId);
            return values.Select(x => new Get3BlogByCategoryIdinNotCurrentBlogIdQueryResult
            {
                BlogId = x.BlogId,
                AuthorId = x.AuthorId,
                BlogCategoryId = x.BlogCategoryId,
                CategoryId = x.BlogCategory.CategoryId,
                BlogImage1 = x.BlogImage1,
                BlogImage2 = x.BlogImage2,
                BlogImage3 = x.BlogImage3,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                SubDescription = x.SubDescription,
                Title = x.Title,
                VideoUrl = x.VideoUrl
            }).ToList();
        }
    }
}
