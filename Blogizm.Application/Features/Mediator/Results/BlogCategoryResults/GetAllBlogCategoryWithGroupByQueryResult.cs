using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Results.BlogCategoryResults
{
    public class GetAllBlogCategoryWithGroupByQueryResult
    {
        public int BlogCategoryId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string BlogCategoryName { get; set; }
    }
}
