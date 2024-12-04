using Blogizm.Application.Features.Mediator.Commands.ContactMessageCommands;
using Blogizm.Application.Features.Mediator.Queries.ContactMessageQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactMessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactMessageController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetContactMessage")]
        public async Task<IActionResult> GetContactMessage()
        {
            var values = await _mediator.Send(new GetContactMessageQuery());
            return Ok(values);
        }
        [HttpPost("CreateContactMessage")]
        public async Task<IActionResult> CreateContactMessage(CreateContactMessageCommand command)
        {
            await _mediator.Send(command);
            return Ok("Mesaj başarıyla eklendi");
        }
        [HttpDelete("RemoveContactMessage/{id}")]
        public async Task<IActionResult> RemoveContactMessage(int id) { 
        await _mediator.Send(new RemoveContactMessageCommand(id));
            return Ok("Mesaj silindi");
        }
        [HttpGet("ContactMessageWhereIsReadableFalseCount")]
        public async Task<IActionResult> ContactMessageWhereIsReadableFalseCount()
        {
          var count=  await _mediator.Send(new ContactMessageWhereIsReadableFalseCountQuery());
            return Ok(count);
        }
        [HttpGet("GetContactMessageWhereIsReadableFalse")]
        public async Task<IActionResult> GetContactMessageWhereIsReadableFalse()
        {
            var values = await _mediator.Send(new GetContactMessageWhereIsReadableFalseQuery());
            return Ok(values);
        }
    }
}
