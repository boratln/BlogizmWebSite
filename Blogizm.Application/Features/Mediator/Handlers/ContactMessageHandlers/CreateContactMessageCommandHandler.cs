using Blogizm.Application.Features.Mediator.Commands.ContactMessageCommands;
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
    public class CreateContactMessageCommandHandler : IRequestHandler<CreateContactMessageCommand>
    {
        private readonly IRepository<ContactMessage> _contactMessageRepository;

        public CreateContactMessageCommandHandler(IRepository<ContactMessage> contactMessageRepository)
        {
            _contactMessageRepository = contactMessageRepository;
        }

        public async Task Handle(CreateContactMessageCommand request, CancellationToken cancellationToken)
        {
            await _contactMessageRepository.Create(new ContactMessage
            {
                Email = request.Email,
                IsReaded = request.IsReaded,
                Message = request.Message,
                NameSurname = request.NameSurname,
                Subject = request.Subject,
            });
        }
    }
}
