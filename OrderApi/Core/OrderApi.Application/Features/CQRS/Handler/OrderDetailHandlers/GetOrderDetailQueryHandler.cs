using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.CQRS.Results.OrderDetailResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Dtos.OrderDtos;
using OrderApi.Domain.Dtos.ProductDtos;
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

            if (values != null)
            {
                foreach (var value in values)
                {
                    value.Order = await _orderRepository.GetByIdAsync(value.OrderId);
                    value.Product = await _productDetailRepository.GetByIdAsync(value.ProductId);
                }

                return values.Select(x => new GetOrderDetailQueryResult
                {
                    OrderDetailId = x.OrderDetailId,
                    OrderId = x.OrderId,
                    Order  = new GetOrderByOrderDetailDto
                    {
                        AddressId=x.Order.AddressId,
                        OrderDate=x.Order.OrderDate,
                        UserId=x.Order.UserId,
                    },
                    ProductId = x.ProductId,
                    Product = new GetProductDto
                    {
                        ProductName=x.Product.ProductName,
                        ProductPrice=x.Product.ProductPrice
                    },
                    ProductAmount = x.ProductAmount
                }).ToList();
            }
            throw new NotFoundException();
        }


    }
}
