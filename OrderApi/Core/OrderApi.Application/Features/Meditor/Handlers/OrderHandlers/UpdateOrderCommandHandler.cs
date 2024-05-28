using MediatR;
using OrderApi.Application.Features.Meditor.Command.OrderCommands;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.OrderHandlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {

        private readonly IRepository<Order> _repository;

        public UpdateOrderCommandHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var values =  await _repository.GetByIdAsync(request.OrderId);
            values.OrderDate = request.OrderDate;
            values.TotalPrice = request.TotalPrice;
            values.UserId = request.UserId;
            await _repository.UpdateAsync(values);
        }
    }
}
