using Blogizm.Application.Features.CQRS.Commands.AboutBannerCommands;
using Blogizm.Application.Features.CQRS.Handlers.AboutBannerHandlers;
using Blogizm.Application.Features.CQRS.Queries.AboutBannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutBannerController : ControllerBase
    {
        private readonly GetAboutBannerQueryHandler _getAboutBannerqueryhandler;
        private readonly GetAboutBannerByIdQueryHandler _getAboutBanneridqueryhandler;
        private readonly CreateAboutBannerCommandHandler _createAboutBannercommandhandler;
        private readonly UpdateAboutBannerCommandHandler _updateAboutBannercommandhandler;
        private readonly RemoveAboutBannerCommandHandler _removeAboutBannercommandhandler;

        public AboutBannerController(RemoveAboutBannerCommandHandler removeAboutBannercommandhandler, UpdateAboutBannerCommandHandler updateAboutBannercommandhandler, CreateAboutBannerCommandHandler createAboutBannercommandhandler, GetAboutBannerByIdQueryHandler getAboutBanneridqueryhandler, GetAboutBannerQueryHandler getAboutBannerqueryhandler)
        {
            _removeAboutBannercommandhandler = removeAboutBannercommandhandler;
            _updateAboutBannercommandhandler = updateAboutBannercommandhandler;
            _createAboutBannercommandhandler = createAboutBannercommandhandler;
            _getAboutBanneridqueryhandler = getAboutBanneridqueryhandler;
            _getAboutBannerqueryhandler = getAboutBannerqueryhandler;
        }
        [HttpGet("GetAllAboutBanner")]
        public async Task<IActionResult> GetAllAboutBanner()
        {
            var list = await _getAboutBannerqueryhandler.Handle();
            return Ok(list);
        }
        [HttpPost("CreateAboutBanner")]
        public async Task<IActionResult> CreateAboutBanner(CreateAboutBannerCommand command)
        {
            await _createAboutBannercommandhandler.Handle(command);
            return Ok("Hakkımızda kısmı başarıyla eklendi");
        }
        [HttpPut("UpdateAboutBanner")]
        public async Task<IActionResult> UpdateAboutBanner(UpdateAboutBannerCommand command)
        {
            await _updateAboutBannercommandhandler.Handle(command);
            return Ok("Hakkımızda kısmı başarıyla güncellendi");
        }
        [HttpDelete("DeleteAboutBanner/{id}")]
        public async Task<IActionResult> DeleteAboutBanner(int id)
        {
            await _removeAboutBannercommandhandler.Handle(new RemoveAboutBannerCommand(id));
            return Ok("Hakkımızda kısmı başarıyla silindi");
        }
        [HttpGet("GetAboutBanner/{id}")]
        public async Task<IActionResult> GetAboutBanner(int id)
        {
            var value = await _getAboutBanneridqueryhandler.Handle(new GetAboutBannerByIdQuery(id));
            if (value.AboutBannerId == 0)
            {
                return NotFound("Hakkımızda kısmı bulunamadı");
            }
            return Ok(value);
        }
    }
}
