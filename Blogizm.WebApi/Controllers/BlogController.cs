using Blogizm.Application.Features.Mediator.Commands;
using Blogizm.Application.Features.Mediator.Commands.BlogCommands;
using Blogizm.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetBlog()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog başarıyla eklendi");

        }
        [HttpGet("GetBlogById/{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog başarılı bir şekilde güncellendi");
        }
        [HttpDelete("RemoveBlog/{id}")]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Blog başarıyla silindi");
        }
        [HttpGet("GetBlogsWithAuthorAndCategories")]
        public async Task<IActionResult> GetAllBlogWithCategories()
        {
            var values = await _mediator.Send(new GetBlogsWithAuthorAndCategoriesQuery());
            return Ok(values);
        }
        [HttpGet("GetBlogByCategoryId/{id}")]
        public async Task<IActionResult> GetBlogByCategoryId(int id)
        {
            var values = await _mediator.Send(new GetBlogByCategoryIdQuery(id));
            return Ok(values);
        }
        [HttpGet("GetBlogWithAuthorAndCategoryDesc")]
        public async Task<IActionResult> GetBlogWithAuthorAndCategoryDesc()
        {
            var values = await _mediator.Send(new GetBlogWithAuthorAndCategoryDescQuery());
            return Ok(values);
        }
        [HttpGet("GetTop3BlogByCategoryId/{id}")]
        public async Task<IActionResult> GetTop3BlogByCategoryId(int id)
        {
            var values = await _mediator.Send(new GetTop3BlogByCategoryIdQuery(id));
            return Ok(values);
        }
    }
}
