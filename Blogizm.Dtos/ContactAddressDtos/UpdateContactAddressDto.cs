using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Dtos.ContactAddressDtos
{
    public class UpdateContactAddressDto
    {
        public int ContactAddressId { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string URL { get; set; }
    }
}
