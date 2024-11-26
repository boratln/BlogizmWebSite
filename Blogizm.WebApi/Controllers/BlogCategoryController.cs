using Blogizm.Application.Features.Mediator.Commands.BlogCategoryCommands;
using Blogizm.Application.Features.Mediator.Queries.BlogCategoryQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async  Task<IActionResult> GetBlogCategory()
        {
            var values = await _mediator.Send(new GetBlogCategoryQuery());
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlogCategory(CreateBlogCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog Kategori başarıyla eklendi");

        }
        [HttpGet("GetBlogCategoryById/{id}")]
        public async Task<IActionResult> GetBlogCategoryById(int id)
        {
            var value = await _mediator.Send(new GetBlogCategoryByIdQuery(id));
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlogCategory(UpdateBlogCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog kategori başarılı bir şekilde güncellendi");
        }
        [HttpDelete("RemoveBlogCategory/{id}")]
        public async Task<IActionResult> RemoveBlogCategory(int id)
        {
            await _mediator.Send(new RemoveBlogCategoryCommand(id));
            return Ok("Blog kategori başarıyla silindi");
        }
        [HttpGet("GetAllBlogWithCategories")]
        public async Task<IActionResult> GetAllBlogWithCategories()
        {
            var values= await _mediator.Send(new GetAllBlogWithCategoriesQuery());
            return Ok(values);
        }
        [HttpGet("GetAllBlogCategoryWithGroupBy")]
        public async Task<IActionResult> GetAllBlogCategoryWithGroupBy()
        {
            var values = await _mediator.Send(new GetAllBlogCategoryWithGroupByQuery());
            return Ok(values);
        }
        [HttpGet("GetBlogCategoryWithCategoryId/{id}")]
        public async Task<IActionResult> GetBlogCategoryWithCategoryId(int id)
        {
            var values=await _mediator.Send(new GetBlogCategoryWithCategoryIdQuery(id));
            return Ok(values);
        }
    }
}
