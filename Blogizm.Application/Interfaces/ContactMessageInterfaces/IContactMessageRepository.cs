using Blogizm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Interfaces.ContactMessageInterfaces
{
    public interface IContactMessageRepository
    {
        Task<List<ContactMessage>> GetContactMessageWhereIsReadableFalse();
         int ContactMessageWhereIsReadableFalseCount();
    }
}
