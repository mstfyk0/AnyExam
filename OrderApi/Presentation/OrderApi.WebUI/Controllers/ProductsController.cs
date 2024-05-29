using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Application.Features.Meditor.Command.OrderCommands;
using OrderApi.Application.Features.Meditor.Command.ProductCommands;
using OrderApi.Application.Features.Meditor.Queries.OrderQueries;
using OrderApi.Application.Features.Meditor.Queries.ProductQueries;

namespace OrderApi.WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllProductList()
        {
            var values = await _mediator.Send(new GetProductQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllProductById([FromRoute] int id)
        {
            var values = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand createProductCommand )
        {
            await _mediator.Send(createProductCommand);
            return Ok("Ürün başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct([FromRoute] int id)
        {
            await _mediator.Send(new RemoveProductCommand(id));
            return Ok("Ürün başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand updateProductCommand)
        {
            await _mediator.Send(updateProductCommand);
            return Ok("Ürün başarıyla güncellendi.");
        }
    }
}
