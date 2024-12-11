using Blogizm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Interfaces.UserInterfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetByFilter(Expression<Func<User, bool>> filter);

    }
}
