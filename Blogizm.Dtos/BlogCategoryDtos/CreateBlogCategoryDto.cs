using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Dtos.BlogCategoryDtos
{
    public class CreateBlogCategoryDto
    {
        public int CategoryId { get; set; }     
        public string Name { get; set; }
    }
}
