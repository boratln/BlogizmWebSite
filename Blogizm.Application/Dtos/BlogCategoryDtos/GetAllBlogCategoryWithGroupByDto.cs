using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Dtos.BlogCategoryDtos
{
    public class GetAllBlogCategoryWithGroupByDto
    {
        public int BlogCategoryId {  get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string BlogCategoryName { get; set; }
    }
}
