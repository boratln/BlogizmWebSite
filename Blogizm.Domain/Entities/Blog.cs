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
        public int BlogCategoryId {  get; set; }
      public BlogCategory BlogCategory { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }     
        public string Title {  get; set; }
        public string Description { get; set; }
        public string SubDescription { get; set; }
        public string CoverImageUrl {  get; set; }
        public DateTime CreatedDate {  get; set; }
        public string? BlogImage1 {  get; set; }
        public string? BlogImage2 {  get; set; }
        public string? BlogImage3 {  get; set; }
        public string? VideoUrl {  get; set; }
       

    }
}
