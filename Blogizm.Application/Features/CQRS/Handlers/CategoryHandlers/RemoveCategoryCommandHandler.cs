using Blogizm.Application.Features.CQRS.Commands.CategoryCommands;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly IRepository<Category> _categoryRepository;

        public RemoveCategoryCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task Handle(RemoveCategoryCommand command)
        {
            var value = await _categoryRepository.GetById(command.Id);
            await _categoryRepository.Remove(value);
        }
    }
}
