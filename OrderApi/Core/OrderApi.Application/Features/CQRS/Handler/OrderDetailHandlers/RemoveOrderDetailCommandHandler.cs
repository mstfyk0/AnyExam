using OrderApi.Application.Features.CQRS.Commands.OrderDetailCommands;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.CQRS.Handler.OrderDetailHandlers
{
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IUnitOfWork _unitOfWork;


        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveOrderDetailCommand removeOrderDetailCommand)
        {
            var value = await _repository.GetByIdAsync(removeOrderDetailCommand.Id);
            _repository.Delete(value);
            await _unitOfWork.Commit();
        }
    }
}
