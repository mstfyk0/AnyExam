using MediatR;
using OrderApi.Application.Features.Meditor.Command.OrderCommands;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.OrderHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {

        private readonly IRepository<Order> _repository;

        public CreateOrderCommandHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Order
            {
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                UserId = request.UserId,

            });
        }
    }
}
