using Blogizm.Application.Features.Mediator.Queries.BlogCategoryQueries;
using Blogizm.Application.Features.Mediator.Results.BlogCategoryResults;
using Blogizm.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Handlers.BlogCategoryHandlers
{
    public class GetAllBlogWithCategoriesQueryHandler : IRequestHandler<GetAllBlogWithCategoriesQuery, List<GetAllBlogWithCategoriesQueryResult>>
    {
        private readonly IBlogCategoryRepository _blogCategoryRepository;

        public GetAllBlogWithCategoriesQueryHandler(IBlogCategoryRepository blogCategoryRepository)
        {
            _blogCategoryRepository = blogCategoryRepository;
        }

        public async Task<List<GetAllBlogWithCategoriesQueryResult>> Handle(GetAllBlogWithCategoriesQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogCategoryRepository.GetAllBlogWithCategories();
            return values.Select(x => new GetAllBlogWithCategoriesQueryResult
            {
                BlogCategoryId = x.BlogCategoryId,
                CategoryId = x.CategoryId,
                Name = x.Name,
                CategoryName=x.Category.Name,
            }).ToList();
        }
    }
}
