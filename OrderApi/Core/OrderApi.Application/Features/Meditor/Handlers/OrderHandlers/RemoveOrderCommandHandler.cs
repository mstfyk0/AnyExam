using MediatR;
using OrderApi.Application.Features.Meditor.Command.OrderCommands;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.OrderHandlers
{
    public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommand>
    {

        private readonly IRepository<Order> _repository;

        public RemoveOrderCommandHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(values);

        }
    }
}
