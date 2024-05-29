using MediatR;
using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.Meditor.Queries.ProductQueries;
using OrderApi.Application.Features.Meditor.Results.ProductResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.ProductHandlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<GetProductQueryResult>>
    {

        private readonly IRepository<Product> _repository;

        public GetProductQueryHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetProductQueryResult>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            if (values != null)
            {

                return values.Select(x => new GetProductQueryResult
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductPrice=x.ProductPrice,
                }).ToList();
            }
            throw new NotFoundException();

        }
    }
}
