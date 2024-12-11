using Blogizm.Application.Features.Mediator.Queries.UserQueries;
using Blogizm.Application.Features.Mediator.Results.UserResults;
using Blogizm.Application.Interfaces;
using Blogizm.Application.Interfaces.UserInterfaces;
using Blogizm.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Handlers.UserHandlers
{
    public class GetCheckUserQueryHandler : IRequestHandler<GetCheckUserQuery, GetCheckUserQueryResult>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Role> _roleRepository;

        public GetCheckUserQueryHandler(IRepository<Role> roleRepository, IRepository<User> userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public async Task<GetCheckUserQueryResult> Handle(GetCheckUserQuery request, CancellationToken cancellationToken)
        {
            var values = new GetCheckUserQueryResult();
            var user=await _userRepository.GetByFilter(x=>x.UserName==request.Username && x.Password==request.Password);
            if (user==null)
            {
                values.IsExist = false;
            }
            else
            {
                {
                    values.IsExist= true;
                    values.Id = user.UserId;
                    values.Username = user.UserName;
                    values.Role = (await _roleRepository.GetByFilter(x => x.RoleId == user.RoleId))?.Name;
                   
                }
            }
            return values;
        }
    }
}
