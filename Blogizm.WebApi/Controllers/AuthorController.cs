using Blogizm.Application.Features.CQRS.Commands.AuthorCommands;
using Blogizm.Application.Features.CQRS.Handlers.AboutHandlers;
using Blogizm.Application.Features.CQRS.Queries.AuthorQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly GetAuthorQueryHandler _getAuthorqueryhandler;
        private readonly GetAuthorByIdQueryHandler _getAuthoridqueryhandler;
        private readonly CreateAuthorCommandHandler _createAuthorcommandhandler;
        private readonly UpdateAuthorCommandHandler _updateAuthorcommandhandler;
        private readonly RemoveAuthorCommandHandler _removeAuthorcommandhandler;

        public AuthorController(RemoveAuthorCommandHandler removeAuthorcommandhandler, UpdateAuthorCommandHandler updateAuthorcommandhandler, CreateAuthorCommandHandler createAuthorcommandhandler, GetAuthorByIdQueryHandler getAuthoridqueryhandler, GetAuthorQueryHandler getAuthorqueryhandler)
        {
            _removeAuthorcommandhandler = removeAuthorcommandhandler;
            _updateAuthorcommandhandler = updateAuthorcommandhandler;
            _createAuthorcommandhandler = createAuthorcommandhandler;
            _getAuthoridqueryhandler = getAuthoridqueryhandler;
            _getAuthorqueryhandler = getAuthorqueryhandler;
        }
        [HttpGet("GetAllAuthor")]
        public async Task<IActionResult> GetAllAuthor()
        {
            var list = await _getAuthorqueryhandler.Handle();
            return Ok(list);
        }
        [HttpPost("CreateAuthor")]
        public async Task<IActionResult> CreateAuthor(CreateAuthorCommand command)
        {
            await _createAuthorcommandhandler.Handle(command);
            return Ok("Yazar kısmı başarıyla eklendi");
        }
        [HttpPut("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand command)
        {
            await _updateAuthorcommandhandler.Handle(command);
            return Ok("Yazar kısmı başarıyla güncellendi");
        }
        [HttpDelete("DeleteAuthor/{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _removeAuthorcommandhandler.Handle(new RemoveAuthorCommand(id));
            return Ok("Yazar kısmı başarıyla silindi");
        }
        [HttpGet("GetAuthor/{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var value = await _getAuthoridqueryhandler.Handle(new GetAuthorByIdQuery(id));
            if (value.AuthorId == 0)
            {
                return NotFound("Yazar kısmı bulunamadı");
            }
            return Ok(value);
        }
    }
}
