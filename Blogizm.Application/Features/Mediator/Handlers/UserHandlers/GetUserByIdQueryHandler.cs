using Blogizm.Application.Features.Mediator.Queries.UserQueries;
using Blogizm.Application.Features.Mediator.Results.UserResults;
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
    internal class GetUserByIdQueryHandler:IRequestHandler<GetUserByIdQuery,GetUserByIdQueryResult>
    {
        private readonly IRepository<User> _userRepository;

        public GetUserByIdQueryHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _userRepository.GetById(request.Id);
            return new GetUserByIdQueryResult
            {
                Email = value.Email,
                isConfirmed = value.isConfirmed,
                Name = value.Name,
                Password = value.Password,
                Surname = value.Surname,
                UserId = value.UserId,
            };
        }
    }
}
