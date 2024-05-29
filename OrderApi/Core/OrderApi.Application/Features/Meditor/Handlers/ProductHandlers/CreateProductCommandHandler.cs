using MediatR;
using OrderApi.Application.Features.Meditor.Command.ProductCommands;
using OrderApi.Application.Features.Meditor.Command.UserCommands;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {

        private readonly IRepository<Product> _repository;
        private readonly IUnitOfWork _unitOfWork;


        public CreateProductCommandHandler(IRepository<Product> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _repository.Create(new Product
            {
                ProductName = request.ProductName,
                ProductPrice = request.ProductPrice,
            });
            await _unitOfWork.Commit();
        }
    }
}
