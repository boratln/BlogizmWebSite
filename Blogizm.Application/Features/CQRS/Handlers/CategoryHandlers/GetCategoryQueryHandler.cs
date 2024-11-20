using Blogizm.Application.Features.CQRS.Results.CategoryResults;
using Blogizm.Application.Interfaces;
using Blogizm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> _categoryRepository;

        public GetCategoryQueryHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values=await _categoryRepository.GetAll();
            return values.Select(x => new GetCategoryQueryResult
            {
                CategoryId = x.CategoryId,
                Name = x.Name,
            }).ToList();
        }
    }
}
