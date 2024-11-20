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
    public class CreateCategoryCommandHandler
    {
        private readonly IRepository<Category> _categoryRepository;

        public CreateCategoryCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task Handle(CreateCategoryCommand command)
        {
            await _categoryRepository.Create(new Category
            {
                Name = command.Name,
            });
        }
    }
}
