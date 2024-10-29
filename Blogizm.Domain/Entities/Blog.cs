using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Domain.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public int CategoryId {  get; set; }
        public int TagId {  get; set; }
        public Tag Tag { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        
       

    }
}
