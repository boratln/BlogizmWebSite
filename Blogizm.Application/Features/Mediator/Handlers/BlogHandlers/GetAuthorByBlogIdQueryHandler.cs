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
    public class GetAuthorByBlogIdQueryHandler : IRequestHandler<GetAuthorByBlogIdQuery, GetAuthorByBlogIdQueryResult>
    {
        private readonly IBlogRepository _blogRepository;

        public GetAuthorByBlogIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<GetAuthorByBlogIdQueryResult> Handle(GetAuthorByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _blogRepository.GetAuthorByBlogId(request.BlogId);
            return new GetAuthorByBlogIdQueryResult
            {
                BlogId = request.BlogId,
                AuthorDescription = author.Author.Description,
                AuthorFullname = author.Author.Name + " " + author.Author.Surname,
                AuthorId = author.AuthorId,
                AuthorImage = author.Author.AuthorImage

            };
        }
    }
}
