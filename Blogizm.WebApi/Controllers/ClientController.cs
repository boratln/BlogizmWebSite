using Blogizm.Application.Features.CQRS.Commands.ClientCommands;
using Blogizm.Application.Features.CQRS.Handlers.AboutHandlers;
using Blogizm.Application.Features.CQRS.Queries.ClientQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly GetClientQueryHandler _getClientqueryhandler;
        private readonly GetClientByIdQueryHandler _getClientidqueryhandler;
        private readonly CreateClientCommandHandler _createClientcommandhandler;
        private readonly UpdateClientCommandHandler _updateClientcommandhandler;
        private readonly RemoveClientCommandHandler _removeClientcommandhandler;

        public ClientController(RemoveClientCommandHandler removeClientcommandhandler, UpdateClientCommandHandler updateClientcommandhandler, CreateClientCommandHandler createClientcommandhandler, GetClientByIdQueryHandler getClientidqueryhandler, GetClientQueryHandler getClientqueryhandler)
        {
            _removeClientcommandhandler = removeClientcommandhandler;
            _updateClientcommandhandler = updateClientcommandhandler;
            _createClientcommandhandler = createClientcommandhandler;
            _getClientidqueryhandler = getClientidqueryhandler;
            _getClientqueryhandler = getClientqueryhandler;
        }
        [HttpGet("GetAllClient")]
        public async Task<IActionResult> GetAllClient()
        {
            var list = await _getClientqueryhandler.Handle();
            return Ok(list);
        }
        [HttpPost("CreateClient")]
        public async Task<IActionResult> CreateClient(CreateClientCommand command)
        {
            await _createClientcommandhandler.Handle(command);
            return Ok("Web Site Çalışanlarımız Kısmı başarıyla eklendi");
        }
        [HttpPut("UpdateClient")]
        public async Task<IActionResult> UpdateClient(UpdateClientCommand command)
        {
            await _updateClientcommandhandler.Handle(command);
            return Ok("Web Site Çalışanlarımız Kısmı başarıyla güncellendi");
        }
        [HttpDelete("DeleteClient/{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _removeClientcommandhandler.Handle(new RemoveClientCommand(id));
            return Ok("Web Site Çalışanlarımız Kısmı başarıyla silindi");
        }
        [HttpGet("GetClient/{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var value = await _getClientidqueryhandler.Handle(new GetClientByIdQuery(id));
            if (value.ClientId == 0)
            {
                return NotFound("Web Site Çalışanlarımız Kısmı bulunamadı");
            }
            return Ok(value);
        }
    }
}
