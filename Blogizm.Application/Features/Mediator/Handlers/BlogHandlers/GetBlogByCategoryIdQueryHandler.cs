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
    public class GetBlogByCategoryIdQueryHandler : IRequestHandler<GetBlogByCategoryIdQuery, List<GetBlogByCategoryIdQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogByCategoryIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetBlogByCategoryIdQueryResult>> Handle(GetBlogByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.GetBlogByCategoryId(request.Id);
            return values.Select(x => new GetBlogByCategoryIdQueryResult
            {
                AuthorId = x.AuthorId,
                BlogCategoryId = x.BlogCategoryId,
                AuthorName=x.Author.Name,
                CategoryName=x.BlogCategory.Category.Name,
                
                BlogId = x.BlogId,
                BlogImage1 = x.BlogImage1,
                BlogImage2 = x.BlogImage2,
                BlogImage3 = x.BlogImage3,
                CategoryId = x.BlogCategory.CategoryId,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Title = x.Title,
                VideoUrl=x.VideoUrl
            }).ToList();

        }
    }
}
