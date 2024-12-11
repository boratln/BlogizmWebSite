using Blogizm.Application.Interfaces.UserInterfaces;
using Blogizm.Domain.Entities;
using Blogizm.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Persistence.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BlogContext _blogContext;

        public UserRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<List<User>> GetByFilter(Expression<Func<User, bool>> filter)
        {
            var values = await _blogContext.Users.Where(filter).ToListAsync();
            return values;
        }
    }
}
