using MediatR;
using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.Meditor.Command.OrderCommands;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.OrderHandlers
{
    public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommand>
    {

        private readonly IRepository<Order> _repository;
        private readonly IUnitOfWork _unitOfWork;


        public RemoveOrderCommandHandler(IRepository<Order> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);

            if(values != null)
            {

                _repository.Delete(values);
                await _unitOfWork.Commit();
            }
            throw new NotFoundIdException(request.Id);
        }
    }
}
