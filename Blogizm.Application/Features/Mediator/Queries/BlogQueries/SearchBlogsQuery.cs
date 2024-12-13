using Blogizm.Application.Features.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Queries.BlogQueries
{
    public class SearchBlogsQuery:IRequest<List<SearchBlogsQueryResult>>
    {
        public string SearchWord {  get; set; }

        public SearchBlogsQuery(string searchWord)
        {
            SearchWord = searchWord;
        }
    }
}
