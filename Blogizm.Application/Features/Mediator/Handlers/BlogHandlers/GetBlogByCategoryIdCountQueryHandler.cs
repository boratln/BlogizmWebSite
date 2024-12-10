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
    public class GetBlogByCategoryIdCountQueryHandler : IRequestHandler<GetBlogByCategoryIdCountQuery, GetBlogByCategoryIdCountQueryResult>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogByCategoryIdCountQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public Task<GetBlogByCategoryIdCountQueryResult> Handle(GetBlogByCategoryIdCountQuery request, CancellationToken cancellationToken)
        {
            var count =  _blogRepository.GetCountByCategoryId(request.CategoryId);
            return Task.FromResult(new GetBlogByCategoryIdCountQueryResult
            {
                BlogCount = count
            });
        }
    }
}
