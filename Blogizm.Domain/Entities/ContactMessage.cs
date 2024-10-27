using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Domain.Entities
{
    public class ContactMessage
    {
        public int ContactMessageId {  get; set; }
        public string NameSurname {  get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsReaded {  get; set; }
    }
}
