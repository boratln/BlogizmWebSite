﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Dtos.AuthorDtos
{
    public class ResultAuthorDto
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string AuthorImage { get; set; }
    }
}