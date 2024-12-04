using Blogizm.Application.Features.Mediator.Queries.ContactMessageQueries;
using Blogizm.Application.Features.Mediator.Results.ContactMessageResults;
using Blogizm.Application.Interfaces.ContactMessageInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Handlers.ContactMessageHandlers
{
    public class GetContactMessageWhereIsReadableFalseQueryHandler : IRequestHandler<GetContactMessageWhereIsReadableFalseQuery, List<GetContactMessageWhereIsReadableFalseQueryResult>>
    {
        private readonly IContactMessageRepository _contactMessageRepository;

        public GetContactMessageWhereIsReadableFalseQueryHandler(IContactMessageRepository contactMessageRepository)
        {
            _contactMessageRepository = contactMessageRepository;
        }

        public async Task<List<GetContactMessageWhereIsReadableFalseQueryResult>> Handle(GetContactMessageWhereIsReadableFalseQuery request, CancellationToken cancellationToken)
        {
            var values = await _contactMessageRepository.GetContactMessageWhereIsReadableFalse();
            return values.Select(x => new GetContactMessageWhereIsReadableFalseQueryResult
            {
                ContactMessageId = x.ContactMessageId,
                CreatedDate = x.CreatedDate,
                Email = x.Email,
                IsReaded = x.IsReaded,
                Message = x.Message,
                NameSurname = x.NameSurname,
                Subject = x.Subject
            }).ToList();

        }
    }
}
