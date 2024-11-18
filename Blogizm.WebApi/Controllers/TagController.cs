using Blogizm.Application.Features.CQRS.Commands.TagCommands;
using Blogizm.Application.Features.CQRS.Handlers.TagHandlers;
using Blogizm.Application.Features.CQRS.Queries.TagQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly GetTagQueryHandler _getTagqueryhandler;
        private readonly GetTagByIdQueryHandler _getTagidqueryhandler;
        private readonly CreateTagCommandHandler _createTagcommandhandler;
        private readonly UpdateTagCommandHandler _updateTagcommandhandler;
        private readonly RemoveTagCommandHandler _removeTagcommandhandler;

        public TagController(RemoveTagCommandHandler removeTagcommandhandler, UpdateTagCommandHandler updateTagcommandhandler, CreateTagCommandHandler createTagcommandhandler, GetTagByIdQueryHandler getTagidqueryhandler, GetTagQueryHandler getTagqueryhandler)
        {
            _removeTagcommandhandler = removeTagcommandhandler;
            _updateTagcommandhandler = updateTagcommandhandler;
            _createTagcommandhandler = createTagcommandhandler;
            _getTagidqueryhandler = getTagidqueryhandler;
            _getTagqueryhandler = getTagqueryhandler;
        }
        [HttpGet("GetAllTag")]
        public async Task<IActionResult> GetAllTag()
        {
            var list = await _getTagqueryhandler.Handle();
            return Ok(list);
        }
        [HttpPost("CreateTag")]
        public async Task<IActionResult> CreateTag(CreateTagCommand command)
        {
            await _createTagcommandhandler.Handle(command);
            return Ok("Etiket Bulutu Kısmı başarıyla eklendi");
        }
        [HttpPut("UpdateTag")]
        public async Task<IActionResult> UpdateTag(UpdateTagCommand command)
        {
            await _updateTagcommandhandler.Handle(command);
            return Ok("Etiket Bulutu Kısmı başarıyla güncellendi");
        }
        [HttpDelete("DeleteTag/{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            await _removeTagcommandhandler.Handle(new RemoveTagCommand(id));
            return Ok("Etiket Bulutu Kısmı başarıyla silindi");
        }
        [HttpGet("GetTag/{id}")]
        public async Task<IActionResult> GetTag(int id)
        {
            var value = await _getTagidqueryhandler.Handle(new GetTagByIdQuery(id));
            if (value.TagId == 0)
            {
                return NotFound("Etiket Bulutu Kısmı bulunamadı");
            }
            return Ok(value);
        }
    }
}
