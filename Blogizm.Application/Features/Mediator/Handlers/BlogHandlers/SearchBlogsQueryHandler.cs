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
    internal class SearchBlogsQueryHandler : IRequestHandler<SearchBlogsQuery, List<SearchBlogsQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public SearchBlogsQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<SearchBlogsQueryResult>> Handle(SearchBlogsQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.SearchBlogs(request.SearchWord);
            return values.Select(x => new SearchBlogsQueryResult
            {
                AuthorId = x.AuthorId,
                BlogCategoryId = x.BlogCategoryId,
                BlogId = x.BlogId,
                BlogImage1 = x.BlogImage1,
                BlogImage2 = x.BlogImage2,
                BlogImage3 = x.BlogImage3,
                CategoryId = x.BlogCategory.Category.CategoryId,
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
