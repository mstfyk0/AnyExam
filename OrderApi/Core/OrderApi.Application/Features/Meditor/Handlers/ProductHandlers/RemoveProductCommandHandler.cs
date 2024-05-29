using MediatR;
using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.Meditor.Command.ProductCommands;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
    {

        private readonly IRepository<Product> _repository;
        private readonly IUnitOfWork _unitOfWork;


        public RemoveProductCommandHandler(IRepository<Product> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);

            if(values != null)
            {
                _repository.Delete(values);
                await _unitOfWork.Commit();
            }
            else
            {
                throw new NotFoundIdException(request.Id);
            }
        }
    }
}
