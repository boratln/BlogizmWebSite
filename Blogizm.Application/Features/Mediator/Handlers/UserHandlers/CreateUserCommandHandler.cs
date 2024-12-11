using Blogizm.Application.Enums;
using Blogizm.Application.Features.Mediator.Commands.UserCommands;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Handlers.UserHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IRepository<User> _userRepository;

        public CreateUserCommandHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.Create(new User
            {
                UserName=request.Username,
                Email = request.Email,
                Name = request.Name,
                RoleId=(int)RolesType.Member,
                Password = request.Password,
                Surname = request.Surname,
                isConfirmed=false
            });
        }
    }
}
