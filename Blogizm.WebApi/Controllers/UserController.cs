using Blogizm.Application.Features.Mediator.Commands.UserCommands;
using Blogizm.Application.Features.Mediator.Queries.UserQueries;
using Blogizm.Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Blogizm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var values = await _mediator.Send(new GetUserQuery());
            return Ok(values);
        }
        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var value = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(value);
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kullanıcı kayıt edildi");
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kullanıcı güncellendi");
        }
        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser(GetCheckUserQuery query)
        {
            var values = await _mediator.Send(query);
            if (values.IsExist)
            {
                return Created("", JwtTokenGenerator.GenerateToken(values));
            }
            else
            {
                return BadRequest("Kullanıcı Adı veya Şifre hatalı");
            }
        }

    }
}
