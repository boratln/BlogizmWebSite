using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Tools
{
    internal class JwtTokenDefaults
    {
        public const string ValidAudience = "https://192.168.1.93";
        public const string ValidIssiuer = "https://192.168.1.93";
        public const string Key = "Blogizm01Blogizm014548+BlogizmProje01214+";
        public const int Expire = 3;
    }
}
