﻿using Blogizm.Application.Features.CQRS.Commands.TagCommands;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Handlers.TagHandlers
{
    public class CreateTagCommandHandler
    {
        private readonly IRepository<Tag> _tagRepository;

        public CreateTagCommandHandler(IRepository<Tag> tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task Handle(CreateTagCommand command)
        {
            await _tagRepository.Create(new Tag
            {
                Title = command.Title,
            });
        }
    }
}