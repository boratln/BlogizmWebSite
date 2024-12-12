using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Results.BlogResults
{
    public class GetAuthorByBlogIdQueryResult
    {
        public int BlogId {  get; set; }
        public int AuthorId { get; set; }
        public string AuthorFullname {  get; set; }
        public string AuthorDescription {  get; set; }
        public string AuthorImage {  get; set; }
    }
}
