using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.CQRS.Results.OrderDetailResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.CQRS.Handler.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();

            if (values != null)
            {

                return values.Select(x => new GetOrderDetailQueryResult
                {
                    OrderDetailId = x.OrderDetailId,
                    ProductAmount = x.ProductAmount,
                    ProductName = x.ProductName,
                    OrderId = x.OrderId,
                    ProductId = x.ProductId,
                    ProductPrice = x.ProductPrice,
                    ProductTotalPrice = x.ProductTotalPrice,


                }).ToList();
            }
            throw new NotFoundException();
        }


    }
}
