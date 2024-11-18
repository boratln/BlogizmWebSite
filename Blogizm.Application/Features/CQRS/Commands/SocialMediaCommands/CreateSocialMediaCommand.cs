﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Commands.SocialMediaCommands
{
    public class CreateSocialMediaCommand
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string URL { get; set; }
    }
}