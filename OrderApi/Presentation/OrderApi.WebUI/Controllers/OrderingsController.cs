using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MulitShop.Order.Application.Features.Meditor.Command.OrderingCommands;
using MulitShop.Order.Application.Features.Meditor.Queries.OrderingQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllOrderingList()
        {
            //Handle tipindeki sınıflara ulaşmak için send kullanılıyor.
            //send içinde Irequesti miras alan sınıfları çağırıcaz
            var values = await _mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllOrderingById([FromRoute] int id)
        {
            //Handle tipindeki sınıflara ulaşmak için send kullanılıyor.
            //send içinde Irequesti miras alan sınıfları çağırıcaz
            var values = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering([FromBody] CreateOrderingCommand createOrderingCommand )
        {
            await _mediator.Send(createOrderingCommand);
            return Ok("Sipraiş başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrdering([FromRoute] int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Sipraiş başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering([FromBody] UpdateOrderingCommand updateOrderingCommand)
        {
            await _mediator.Send(updateOrderingCommand);
            return Ok("Sipraiş başarıyla güncellendi.");
        }
    }
}
