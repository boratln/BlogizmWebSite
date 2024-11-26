using Blogizm.Application.Features.Mediator.Queries.BlogCategoryQueries;
using Blogizm.Application.Features.Mediator.Results.BlogCategoryResults;
using Blogizm.Application.Interfaces.BlogCategoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Handlers.BlogCategoryHandlers
{
    public class GetBlogCategoryWithCategoryIdQueryHandler : IRequestHandler<GetBlogCategoryWithCategoryIdQuery, List<GetBlogCategoryWithCategoryIdQueryResult>>
    {
        private readonly IBlogCategoryRepository _blogCategoryRepository;

        public GetBlogCategoryWithCategoryIdQueryHandler(IBlogCategoryRepository blogCategoryRepository)
        {
            _blogCategoryRepository = blogCategoryRepository;
        }

        public async Task<List<GetBlogCategoryWithCategoryIdQueryResult>> Handle(GetBlogCategoryWithCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogCategoryRepository.GetBlogCategoryWithCategoryId(request.Id);
            return values.Select(x => new GetBlogCategoryWithCategoryIdQueryResult
            {
                BlogCategoryId = x.BlogCategoryId,
                CategoryId = x.CategoryId,
                Name = x.Name
            }).ToList();
        }
    }
}
