using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Dtos.UserDtos
{
    public class TokenResponseDto
    {
        public string Token { get; set; }
        public DateTime Expire_Date { get; set; }

        public TokenResponseDto( string token, DateTime expire_Date)
        {
            Expire_Date = expire_Date;
            Token = token;
        }
    }
}
