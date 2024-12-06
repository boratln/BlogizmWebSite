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
    public class GetTop3BlogByCategoryIdQueryHandler : IRequestHandler<GetTop3BlogByCategoryIdQuery, List<GetTop3BlogByCategoryIdQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetTop3BlogByCategoryIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetTop3BlogByCategoryIdQueryResult>> Handle(GetTop3BlogByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.GetTop3BlogByCategoryId(request.CategoryId);
            return values.Select(x => new GetTop3BlogByCategoryIdQueryResult
            {
                AuthorId = x.AuthorId,
                AuthorName = x.Author.Name + " " + x.Author.Surname,
                BlogCategoryId = x.BlogCategoryId,
                BlogCategoryName = x.BlogCategory.Name,
                BlogId = x.BlogId,
                BlogImage1 = x.BlogImage1,
                BlogImage2 = x.BlogImage2,
                BlogImage3 = x.BlogImage3,
                CategoryName = x.BlogCategory.Category.Name,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Title = x.Title,
                VideoUrl = x.VideoUrl,
            }).ToList();
        }
    }
}
