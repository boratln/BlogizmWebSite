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
    public class Get3BlogByCategoryIdQueryHandler : IRequestHandler<Get3BlogByCategoryIdQuery, List<Get3BlogByCategoryIdQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public Get3BlogByCategoryIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<Get3BlogByCategoryIdQueryResult>> Handle(Get3BlogByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.Get3BlogByCategoryId(request.CategoryId);
            return values.Select(x => new Get3BlogByCategoryIdQueryResult
            {
                BlogImage1 = x.BlogImage1,
                BlogId = x.BlogId,
                CategoryId = x.BlogCategory.CategoryId,
                AuthorId = x.AuthorId,
                BlogCategoryId = x.BlogCategoryId,
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
