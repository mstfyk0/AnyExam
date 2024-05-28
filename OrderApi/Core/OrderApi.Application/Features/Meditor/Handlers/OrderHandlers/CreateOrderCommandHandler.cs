using MediatR;
using OrderApi.Application.Features.Meditor.Command.OrderCommands;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.OrderHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {

        private readonly IRepository<Order> _repository;
        private readonly IUnitOfWork _unitOfWork;


        public CreateOrderCommandHandler(IRepository<Order> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            _repository.Create(new Order
            {
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                UserId = request.UserId,

            });
            await _unitOfWork.Commit();
        }
    }
}
