using Blogizm.Application.Features.Mediator.Queries.BlogCategoryQueries;
using Blogizm.Application.Features.Mediator.Results.BlogCategoryResults;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Handlers.BlogCategoryHandlers
{
    public class GetBlogCategoryByIdQueryHandler : IRequestHandler<GetBlogCategoryByIdQuery, GetBlogCategoryByIdQueryResult>
    {
        private readonly IRepository<BlogCategory> _blogCategoryRepository;

        public GetBlogCategoryByIdQueryHandler(IRepository<BlogCategory> blogCategoryRepository)
        {
            _blogCategoryRepository = blogCategoryRepository;
        }

        public async Task<GetBlogCategoryByIdQueryResult> Handle(GetBlogCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _blogCategoryRepository.GetById(request.Id);
            return new GetBlogCategoryByIdQueryResult
            {
                BlogCategoryId = value.BlogCategoryId,
                CategoryId = value.CategoryId,
                Name = value.Name,
            };
        }
    }
}
