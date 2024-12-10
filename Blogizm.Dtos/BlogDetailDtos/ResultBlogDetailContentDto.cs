using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Dtos.BlogDetailDtos
{
    public class ResultBlogDetailContentDto
    {
        
            public int blogId { get; set; }
            public int blogCategoryId { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string coverImageUrl { get; set; }
            public DateTime createdDate { get; set; }
            public string blogImage1 { get; set; }
            public string blogImage2 { get; set; }
            public string blogImage3 { get; set; }
            public object videoUrl { get; set; }
        

    }
}
