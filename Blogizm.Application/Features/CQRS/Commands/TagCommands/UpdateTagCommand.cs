﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Commands.TagCommands
{
    public class UpdateTagCommand
    {
        public int TagId { get; set; }
        public string Title { get; set; }
    }
}
