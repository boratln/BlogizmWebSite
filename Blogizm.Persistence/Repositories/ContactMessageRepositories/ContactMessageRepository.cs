using Blogizm.Application.Interfaces.ContactMessageInterfaces;
using Blogizm.Domain.Entities;
using Blogizm.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Persistence.Repositories.ContactMessageRepositories
{
    public class ContactMessageRepository : IContactMessageRepository
    {
        private readonly BlogContext _blogContext;

        public ContactMessageRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public int ContactMessageWhereIsReadableFalseCount()
        {
            var count = _blogContext.ContactMessages.Where(x => x.IsReaded == false).Count();
            return count;
        }

        public async Task<List<ContactMessage>> GetContactMessageWhereIsReadableFalse()
        {
            var values = await _blogContext.ContactMessages.Where(x => x.IsReaded == false).ToListAsync();
            return values;
        }
    }
}
