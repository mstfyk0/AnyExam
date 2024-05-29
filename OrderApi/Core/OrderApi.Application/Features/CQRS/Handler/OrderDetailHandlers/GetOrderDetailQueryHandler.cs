using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.CQRS.Results.OrderDetailResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.CQRS.Handler.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<Product> _productDetailRepository;
        private readonly IRepository<Order> _orderRepository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> orderDetailRepository, IRepository<Product> productDetailRepository, IRepository<Order> orderRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _productDetailRepository = productDetailRepository;
            _orderRepository = orderRepository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await _orderDetailRepository.GetAllAsync();
            
            foreach (var value in values)
            {
                value.Order = await _orderRepository.GetByIdAsync(value.OrderId);   
                value.Product = await _productDetailRepository.GetByIdAsync(value.ProductId);   
            }

            if (values != null)
            {

                return values.Select(x => new GetOrderDetailQueryResult
                {
                    OrderDetailId = x.OrderDetailId,
                    OrderId = x.OrderId,
                    Order  =x.Order,
                    ProductId = x.ProductId,
                    Product = x.Product,
                    ProductAmount = x.ProductAmount
                }).ToList();
            }
            throw new NotFoundException();
        }


    }
}
