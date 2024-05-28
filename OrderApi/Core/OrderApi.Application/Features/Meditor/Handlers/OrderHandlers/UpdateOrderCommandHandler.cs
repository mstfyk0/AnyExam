using MediatR;
using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.Meditor.Command.OrderCommands;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.OrderHandlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {

        private readonly IRepository<Order> _repository;
        private readonly IUnitOfWork _unitOfWork;


        public UpdateOrderCommandHandler(IRepository<Order> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var values =  await _repository.GetByIdAsync(request.OrderId);

            if (values != null)
            {

                values.OrderDate = request.OrderDate;
                values.TotalPrice = request.TotalPrice;
                values.UserId = request.UserId;
                _repository.Update(values);
                await _unitOfWork.Commit();
            }
            else
            {
                throw new NotFoundIdException(request.OrderId);
            }
        }
    }
}
