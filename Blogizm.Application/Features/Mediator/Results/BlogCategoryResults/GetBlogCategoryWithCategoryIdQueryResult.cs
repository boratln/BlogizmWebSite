using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Results.BlogCategoryResults
{
    public class GetBlogCategoryWithCategoryIdQueryResult
    {
        public int BlogCategoryId {  get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
