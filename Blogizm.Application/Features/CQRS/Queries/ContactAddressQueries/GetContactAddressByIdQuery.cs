using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Queries.ContactAddressQueries
{
    public class GetContactAddressByIdQuery
    {
        public int Id { get; set; }

        public GetContactAddressByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
