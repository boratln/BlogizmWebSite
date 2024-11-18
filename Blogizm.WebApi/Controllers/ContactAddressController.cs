using Blogizm.Application.Features.CQRS.Commands.ContactAddressCommands;
using Blogizm.Application.Features.CQRS.Handlers.AboutHandlers;
using Blogizm.Application.Features.CQRS.Handlers.ContactAddressHandlers;
using Blogizm.Application.Features.CQRS.Queries.ContactAddressQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogizm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactAddressController : ControllerBase
    {
        private readonly GetContactAddressQueryHandler _getContactAddressqueryhandler;
        private readonly GetContactAddressByIdQueryHandler _getContactAddressidqueryhandler;
        private readonly CreateContactAddressCommandHandler _createContactAddresscommandhandler;
        private readonly UpdateContactAddressCommandHandler _updateContactAddresscommandhandler;
        private readonly RemoveContactAddressCommandHandlerr _removeContactAddresscommandhandler;

        public ContactAddressController(RemoveContactAddressCommandHandlerr removeContactAddresscommandhandler, UpdateContactAddressCommandHandler updateContactAddresscommandhandler, CreateContactAddressCommandHandler createContactAddresscommandhandler, GetContactAddressByIdQueryHandler getContactAddressidqueryhandler, GetContactAddressQueryHandler getContactAddressqueryhandler)
        {
            _removeContactAddresscommandhandler = removeContactAddresscommandhandler;
            _updateContactAddresscommandhandler = updateContactAddresscommandhandler;
            _createContactAddresscommandhandler = createContactAddresscommandhandler;
            _getContactAddressidqueryhandler = getContactAddressidqueryhandler;
            _getContactAddressqueryhandler = getContactAddressqueryhandler;
        }
        [HttpGet("GetAllContactAddress")]
        public async Task<IActionResult> GetAllContactAddress()
        {
            var list = await _getContactAddressqueryhandler.Handle();
            return Ok(list);
        }
        [HttpPost("CreateContactAddress")]
        public async Task<IActionResult> CreateContactAddress(CreateContactAddressCommand command)
        {
            await _createContactAddresscommandhandler.Handle(command);
            return Ok("İletişim Adres Kısmı başarıyla eklendi");
        }
        [HttpPut("UpdateContactAddress")]
        public async Task<IActionResult> UpdateContactAddress(UpdateContactAddressCommand command)
        {
            await _updateContactAddresscommandhandler.Handle(command);
            return Ok("İletişim Adres Kısmı başarıyla güncellendi");
        }
        [HttpDelete("DeleteContactAddress/{id}")]
        public async Task<IActionResult> DeleteContactAddress(int id)
        {
            await _removeContactAddresscommandhandler.Handle(new RemoveContactAddressCommand(id));
            return Ok("İletişim Adres Kısmı başarıyla silindi");
        }
        [HttpGet("GetContactAddress/{id}")]
        public async Task<IActionResult> GetContactAddress(int id)
        {
            var value = await _getContactAddressidqueryhandler.Handle(new GetContactAddressByIdQuery(id));
            if (value.ContactAddressId == 0)
            {
                return NotFound("İletişim Adres Kısmı bulunamadı");
            }
            return Ok(value);
        }
    }
}
