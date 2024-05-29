using MediatR;
using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.Meditor.Queries.ProductQueries;
using OrderApi.Application.Features.Meditor.Results.ProductResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.ProductHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
    {

        private readonly IRepository<Product> _repository;

        public GetProductByIdQueryHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);

            if (values != null)
            {
                return new GetProductByIdQueryResult
                {
                    ProductId = values.ProductId,
                    ProductName = values.ProductName,
                    ProductPrice = values.ProductPrice
                };
            }
            throw new NotFoundIdException(request.Id);
        }
    }
}
