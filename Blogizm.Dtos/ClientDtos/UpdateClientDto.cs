using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Dtos.ClientDtos
{
    public class UpdateClientDto
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientDesc { get; set; }
        public string ClientImage { get; set; }
    }
}
