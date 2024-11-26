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
    public class GetAllBlogCategoryWithGroupByQueryHandler : IRequestHandler<GetAllBlogCategoryWithGroupByQuery, List<GetAllBlogCategoryWithGroupByQueryResult>>
    {
        private readonly IBlogCategoryRepository _blogCategoryRepository;

        public GetAllBlogCategoryWithGroupByQueryHandler(IBlogCategoryRepository blogCategoryRepository)
        {
            _blogCategoryRepository = blogCategoryRepository;
        }

        public async Task<List<GetAllBlogCategoryWithGroupByQueryResult>> Handle(GetAllBlogCategoryWithGroupByQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogCategoryRepository.GetAllBlogCategoryWithGroupBy();
            return values.Select(x => new GetAllBlogCategoryWithGroupByQueryResult
            {
                BlogCategoryId=x.BlogCategoryId,
                BlogCategoryName = x.BlogCategoryName,
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
            }).ToList();

        }
    }
}
