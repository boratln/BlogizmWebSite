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
    public class RemoveContactMessageCommandHandler : IRequestHandler<RemoveContactMessageCommand>
    {
        private readonly IRepository<ContactMessage> _contactMessageRepository;

        public RemoveContactMessageCommandHandler(IRepository<ContactMessage> contactMessageRepository)
        {
            _contactMessageRepository = contactMessageRepository;
        }

        public async Task Handle(RemoveContactMessageCommand request, CancellationToken cancellationToken)
        {
            var value = await _contactMessageRepository.GetById(request.Id);
            await _contactMessageRepository.Remove(value);
        }
    }
}
