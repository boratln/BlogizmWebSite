using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Domain.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int UserId {  get; set; }
        public User User {  get; set; }
        public int BlogId {  get; set; }
        public Blog Blog { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedDate {  get; set; }

    }
}
