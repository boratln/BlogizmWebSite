using Blogizm.Application.Features.CQRS.Commands.CategoryCommands;
using Blogizm.Application.Features.CQRS.Handlers.CategoryHandlers;
using Blogizm.Application.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly GetCategoryQueryHandler _getCategoryqueryhandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryidqueryhandler;
        private readonly CreateCategoryCommandHandler _createCategorycommandhandler;
        private readonly UpdateCategoryCommandHandler _updateCategorycommandhandler;
        private readonly RemoveCategoryCommandHandler _removeCategorycommandhandler;

        public CategoryController(RemoveCategoryCommandHandler removeCategorycommandhandler, UpdateCategoryCommandHandler updateCategorycommandhandler, CreateCategoryCommandHandler createCategorycommandhandler, GetCategoryByIdQueryHandler getCategoryidqueryhandler, GetCategoryQueryHandler getCategoryqueryhandler)
        {
            _removeCategorycommandhandler = removeCategorycommandhandler;
            _updateCategorycommandhandler = updateCategorycommandhandler;
            _createCategorycommandhandler = createCategorycommandhandler;
            _getCategoryidqueryhandler = getCategoryidqueryhandler;
            _getCategoryqueryhandler = getCategoryqueryhandler;
        }
        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var list = await _getCategoryqueryhandler.Handle();
            return Ok(list);
        }
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategorycommandhandler.Handle(command);
            return Ok("Hakkımızda kısmı başarıyla eklendi");
        }
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategorycommandhandler.Handle(command);
            return Ok("Hakkımızda kısmı başarıyla güncellendi");
        }
        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _removeCategorycommandhandler.Handle(new RemoveCategoryCommand(id));
            return Ok("Hakkımızda kısmı başarıyla silindi");
        }
        [HttpGet("GetCategory/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var value = await _getCategoryidqueryhandler.Handle(new GetCategoryByIdQuery(id));
            if (value.CategoryId == 0)
            {
                return NotFound("Hakkımızda kısmı bulunamadı");
            }
            return Ok(value);
        }
    }
}
