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
    public class BlogAndBlogCategoryCountByCategoryIdQueryHandler : IRequestHandler<BlogAndBlogCategoryCountByCategoryIdQuery, List<BlogAndBlogCategoryCountByCategoryIdQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public BlogAndBlogCategoryCountByCategoryIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<BlogAndBlogCategoryCountByCategoryIdQueryResult>> Handle(BlogAndBlogCategoryCountByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.BlogAndBlogCategoryCountByCategoryId(request.CategoryId);
            return values.Select(x => new BlogAndBlogCategoryCountByCategoryIdQueryResult
            {
                BlogCategoryName = x.BlogCategoryName,
                BlogCount = x.BlogCount
            }).ToList();
        }
    }
}
