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
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<GetUserQueryResult>>
    {
        private readonly IRepository<User>_userRepository;

        public GetUserQueryHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<GetUserQueryResult>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
           var values=await _userRepository.GetAll();
            return values.Select(x => new GetUserQueryResult
            {
                Email = x.Email,
                isConfirmed = x.isConfirmed,
                Name = x.Name,
                Password = x.Password,
                Surname = x.Surname,
                UserId = x.UserId,
            }).ToList();
        }
    }
}
