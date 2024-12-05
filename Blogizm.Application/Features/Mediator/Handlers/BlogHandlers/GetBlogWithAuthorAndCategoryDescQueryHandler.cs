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
    public class GetBlogWithAuthorAndCategoryDescQueryHandler:IRequestHandler<GetBlogWithAuthorAndCategoryDescQuery,List<GetBlogWithAuthorAndCategoryDescQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogWithAuthorAndCategoryDescQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetBlogWithAuthorAndCategoryDescQueryResult>> Handle(GetBlogWithAuthorAndCategoryDescQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.GetBlogWithAuthorAndCategoryDesc();
            return values.Select(x=>new GetBlogWithAuthorAndCategoryDescQueryResult
            {
                AuthorId = x.AuthorId,
                AuthorName=x.Author.Name+" "+x.Author.Surname,
                BlogCategoryName=x.BlogCategory.Name,
                BlogId=x.BlogId,
                BlogImage1=x.BlogImage1,
                BlogCategoryId=x.BlogCategoryId,
                BlogImage2=x.BlogImage2,
                BlogImage3=x.BlogImage3,
                CategoryName=x.BlogCategory.Category.Name,
                CoverImageUrl=x.CoverImageUrl,
                CreatedDate=x.CreatedDate,
                Description=x.Description,
                Title=x.Title,
                VideoUrl=x.VideoUrl,
            }).ToList();
        }
    }
}
