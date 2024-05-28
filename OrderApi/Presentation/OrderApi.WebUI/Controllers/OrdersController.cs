using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Application.Features.Meditor.Command.OrderCommands;
using OrderApi.Application.Features.Meditor.Queries.OrderQueries;

namespace OrderApi.WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllOrderList()
        {
            var values = await _mediator.Send(new GetOrderQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllOrderById([FromRoute] int id)
        {
            var values = await _mediator.Send(new GetOrderByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand createOrderCommand )
        {
            await _mediator.Send(createOrderCommand);
            return Ok("Sipraiş başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrder([FromRoute] int id)
        {
            await _mediator.Send(new RemoveOrderCommand(id));
            return Ok("Sipraiş başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommand updateOrderCommand)
        {
            await _mediator.Send(updateOrderCommand);
            return Ok("Sipraiş başarıyla güncellendi.");
        }
    }
}
