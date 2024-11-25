using Blogizm.Application.Features.Mediator.Queries.ContactMessageQueries;
using Blogizm.Application.Features.Mediator.Results.ContactMessageResults;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Handlers.ContactMessageHandlers
{
    public class GetContactMessageQueryHandler : IRequestHandler<GetContactMessageQuery, List<GetContactMessageQueryResult>>
    {
        private readonly IRepository<ContactMessage> _contactMessageRepository;

        public GetContactMessageQueryHandler(IRepository<ContactMessage> contactMessageRepository)
        {
            _contactMessageRepository = contactMessageRepository;
        }

        public async Task<List<GetContactMessageQueryResult>> Handle(GetContactMessageQuery request, CancellationToken cancellationToken)
        {
            var values=await _contactMessageRepository.GetAll();
            return values.Select(x => new GetContactMessageQueryResult
            {
                ContactMessageId = x.ContactMessageId,
                Email = x.Email,
                IsReaded = x.IsReaded,
                Message = x.Message,
                NameSurname = x.NameSurname,
                Subject = x.Subject
            }).ToList();
        }
    }
}
