﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Queries.AuthorQueries
{
    public class GetAuthorByIdQuery
    {
        public int Id { get; set; }

        public GetAuthorByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
