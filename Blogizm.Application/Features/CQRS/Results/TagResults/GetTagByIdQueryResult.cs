using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Results.TagResults
{
    public class GetTagByIdQueryResult
    {
        public int TagId { get; set; }
        public string Title { get; set; }
    }
}
