using MediatR;
using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.Meditor.Command.ProductCommands;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {

        private readonly IRepository<Product> _repository;
        private readonly IUnitOfWork _unitOfWork;


        public UpdateProductCommandHandler(IRepository<Product> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var values =  await _repository.GetByIdAsync(request.ProductId);

            if (values != null)
            {
                values.ProductId = request.ProductId;
                values.ProductName = request.ProductName;
                values.ProductPrice = request.ProductPrice;
                _repository.Update(values);
                await _unitOfWork.Commit();
            }
            else
            {
                throw new NotFoundIdException(request.ProductId);
            }
        }
    }
}
