﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Commands
{
    public class RemoveAboutCommand
    {
        public int Id { get; set; }

        public RemoveAboutCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
