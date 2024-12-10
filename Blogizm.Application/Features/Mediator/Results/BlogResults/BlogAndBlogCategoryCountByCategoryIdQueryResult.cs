using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Results.BlogResults
{
    public class BlogAndBlogCategoryCountByCategoryIdQueryResult
    {
        public int BlogCount { get; set; }
        public string BlogCategoryName { get; set; }
    }
}
