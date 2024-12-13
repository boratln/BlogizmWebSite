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
    public class GetLast3BlogQueryHandler : IRequestHandler<GetLast3BlogQuery, List<GetLast3BlogQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetLast3BlogQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetLast3BlogQueryResult>> Handle(GetLast3BlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.GetLast3Blog();
            return values.Select(x => new GetLast3BlogQueryResult
            {
                AuthorId = x.AuthorId,
                BlogCategoryId = x.BlogCategoryId,
                CategoryId=x.BlogCategory.Category.CategoryId,
                BlogId = x.BlogId,
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
