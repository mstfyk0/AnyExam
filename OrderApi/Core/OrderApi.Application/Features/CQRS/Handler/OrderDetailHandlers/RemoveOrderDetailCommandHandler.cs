using OrderApi.Application.Features.CQRS.Commands.OrderDetailCommands;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.CQRS.Handler.OrderDetailHandlers
{
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderDetailCommand removeOrderDetailCommand)
        {
            var value = await _repository.GetByIdAsync(removeOrderDetailCommand.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
