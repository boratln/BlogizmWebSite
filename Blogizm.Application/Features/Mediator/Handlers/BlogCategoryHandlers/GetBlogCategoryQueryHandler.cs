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
    public class GetBlogCategoryQueryHandler : IRequestHandler<GetBlogCategoryQuery, List<GetBlogCategoryQueryResult>>
    {
        private readonly IRepository<BlogCategory> _blogCategoryrepository;

        public GetBlogCategoryQueryHandler(IRepository<BlogCategory> blogCategoryrepository)
        {
            _blogCategoryrepository = blogCategoryrepository;
        }

        public async Task<List<GetBlogCategoryQueryResult>> Handle(GetBlogCategoryQuery request, CancellationToken cancellationToken)
        {
           var values=await _blogCategoryrepository.GetAll();
            return values.Select(x => new GetBlogCategoryQueryResult
            {
                BlogCategoryId = x.BlogCategoryId,
                CategoryId = x.CategoryId,
                Name = x.Name
            }).ToList();
        }
    }
}
