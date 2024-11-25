﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.Mediator.Commands.ContactMessageCommands
{
    public class RemoveContactMessageCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveContactMessageCommand(int ıd)
        {
            Id = ıd;
        }
    }
}