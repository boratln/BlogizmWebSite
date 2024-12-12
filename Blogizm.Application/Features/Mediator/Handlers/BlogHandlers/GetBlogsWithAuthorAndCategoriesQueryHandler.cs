using Blogizm.Application.Features.Mediator.Queries.BlogQueries;
using Blogizm.Application.Features.Mediator.Results.BlogResults;
using Blogizm.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace Blogizm.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogsWithAuthorAndCategoriesQueryHandler : IRequestHandler<GetBlogsWithAuthorAndCategoriesQuery, List<GetBlogsWithAuthorAndCategoriesQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogsWithAuthorAndCategoriesQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetBlogsWithAuthorAndCategoriesQueryResult>> Handle(GetBlogsWithAuthorAndCategoriesQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.GetBlogsWithAuthorAndCategories();
            return values.Select(x => new GetBlogsWithAuthorAndCategoriesQueryResult
            {
                AuthorId = x.AuthorId,
                AuthorName = x.Author.Name + " " + x.Author.Surname,
                BlogCategoryId = x.BlogCategoryId,
                BlogCategoryName = x.BlogCategory.Name,
                CategoryName = x.BlogCategory.Category.Name,
                BlogId = x.BlogId,
                BlogImage1 = x.BlogImage1,
                BlogImage2 = x.BlogImage2,
                BlogImage3 = x.BlogImage3,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                SubDescription=x.SubDescription,
                Title = x.Title,
                VideoUrl=x.VideoUrl,
            }).ToList();
        }
    }
}
