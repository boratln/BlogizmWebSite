using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Results.ContactAddressResults
{
    public class GetContactAddressByIdQueryResult
    {
        public int ContactAddressId { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }

        public string URL { get; set; }
    }
}
