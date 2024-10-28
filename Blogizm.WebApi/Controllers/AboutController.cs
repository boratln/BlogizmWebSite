using Blogizm.Application.Features.CQRS.Commands.AboutCommands;
using Blogizm.Application.Features.CQRS.Handlers.AboutHandlers;
using Blogizm.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly GetAboutQueryHandler _getaboutqueryhandler;
        private readonly GetAboutByIdQueryHandler _getaboutidqueryhandler;
        private readonly CreateAboutCommandHandler _createaboutcommandhandler;
        private readonly UpdateAboutCommandHandler _updateaboutcommandhandler;
        private readonly RemoveAboutCommandHandler _removeaboutcommandhandler;

        public AboutController(RemoveAboutCommandHandler removeaboutcommandhandler, UpdateAboutCommandHandler updateaboutcommandhandler, CreateAboutCommandHandler createaboutcommandhandler, GetAboutByIdQueryHandler getaboutidqueryhandler, GetAboutQueryHandler getaboutqueryhandler)
        {
            _removeaboutcommandhandler = removeaboutcommandhandler;
            _updateaboutcommandhandler = updateaboutcommandhandler;
            _createaboutcommandhandler = createaboutcommandhandler;
            _getaboutidqueryhandler = getaboutidqueryhandler;
            _getaboutqueryhandler = getaboutqueryhandler;
        }
        [HttpGet("GetAllAbout")]
        public async Task<IActionResult> GetAllAbout()
        {
            var list = await _getaboutqueryhandler.Handle();
            return Ok(list);
        }
        [HttpPost("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
             await _createaboutcommandhandler.Handle(command);
            return Ok("Hakkımızda kısmı başarıyla eklendi");
        }
        [HttpPut("UpdateAbout")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _updateaboutcommandhandler.Handle(command);
            return Ok("Hakkımızda kısmı başarıyla güncellendi");
        }
        [HttpDelete("DeleteAbout/{id}")]
        public async Task<IActionResult>DeleteAbout(int id)
        {
            await _removeaboutcommandhandler.Handle(new RemoveAboutCommand(id));
            return Ok("Hakkımızda kısmı başarıyla silindi");
        }
        [HttpGet("GetAbout/{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var value = await _getaboutidqueryhandler.Handle(new GetAboutByIdQuery(id));
            if (value.AboutId == 0)
            {
                return NotFound("Hakkımızda kısmı bulunamadı");
            }         
            return Ok(value);
        }
    }
}
