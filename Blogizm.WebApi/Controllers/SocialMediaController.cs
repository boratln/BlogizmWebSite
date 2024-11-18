using Blogizm.Application.Features.CQRS.Commands.SocialMediaCommands;
using Blogizm.Application.Features.CQRS.Handlers.SocialMediaHandlers;
using Blogizm.Application.Features.CQRS.Queries.SocialMediaQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly GetSocialMediaQueryHandler _getSocialMediaqueryhandler;
        private readonly GetSocialMediaByIdQueryHandler _getSocialMediaidqueryhandler;
        private readonly CreateSocialMediaCommandHandler _createSocialMediacommandhandler;
        private readonly UpdateSocialMediaCommandHandler _updateSocialMediacommandhandler;
        private readonly RemoveSocialMediaCommandHandler _removeSocialMediacommandhandler;

        public SocialMediaController(RemoveSocialMediaCommandHandler removeSocialMediacommandhandler, UpdateSocialMediaCommandHandler updateSocialMediacommandhandler, CreateSocialMediaCommandHandler createSocialMediacommandhandler, GetSocialMediaByIdQueryHandler getSocialMediaidqueryhandler, GetSocialMediaQueryHandler getSocialMediaqueryhandler)
        {
            _removeSocialMediacommandhandler = removeSocialMediacommandhandler;
            _updateSocialMediacommandhandler = updateSocialMediacommandhandler;
            _createSocialMediacommandhandler = createSocialMediacommandhandler;
            _getSocialMediaidqueryhandler = getSocialMediaidqueryhandler;
            _getSocialMediaqueryhandler = getSocialMediaqueryhandler;
        }
        [HttpGet("GetAllSocialMedia")]
        public async Task<IActionResult> GetAllSocialMedia()
        {
            var list = await _getSocialMediaqueryhandler.Handle();
            return Ok(list);
        }
        [HttpPost("CreateSocialMedia")]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
        {
            await _createSocialMediacommandhandler.Handle(command);
            return Ok("Sosyal Medya Kısmı başarıyla eklendi");
        }
        [HttpPut("UpdateSocialMedia")]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
        {
            await _updateSocialMediacommandhandler.Handle(command);
            return Ok("Sosyal Medya Kısmı başarıyla güncellendi");
        }
        [HttpDelete("DeleteSocialMedia/{id}")]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            await _removeSocialMediacommandhandler.Handle(new RemoveSocialMediaCommand(id));
            return Ok("Sosyal Medya Kısmı başarıyla silindi");
        }
        [HttpGet("GetSocialMedia/{id}")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var value = await _getSocialMediaidqueryhandler.Handle(new GetSocialMediaByIdQuery(id));
            if (value.SocialMediaId == 0)
            {
                return NotFound("Sosyal Medya Kısmı bulunamadı");
            }
            return Ok(value);
        }
    }
}
