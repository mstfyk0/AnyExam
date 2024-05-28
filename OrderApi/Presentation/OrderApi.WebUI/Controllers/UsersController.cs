using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Application.Features.Meditor.Command.OrderCommands;
using OrderApi.Application.Features.Meditor.Command.UserCommands;
using OrderApi.Application.Features.Meditor.Queries.OrderQueries;
using OrderApi.Application.Features.Meditor.Queries.UserQueries;

namespace OrderApi.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllUserList()
        {
            var values = await _mediator.Send(new GetUserQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllUserById([FromRoute] int id)
        {
            var values = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand createUserCommand )
        {
            await _mediator.Send(createUserCommand);
            return Ok("Kullanıcı başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUser([FromRoute] int id)
        {
            await _mediator.Send(new RemoveUserCommand(id));
            return Ok("Kullanıcı başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand updateUserCommand)
        {
            await _mediator.Send(updateUserCommand);
            return Ok("Kullanıcı başarıyla güncellendi.");
        }
    }
}
