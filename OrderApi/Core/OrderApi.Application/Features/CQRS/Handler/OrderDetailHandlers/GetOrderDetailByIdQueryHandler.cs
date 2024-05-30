using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.CQRS.Querys.OrderDetailQuerys;
using OrderApi.Application.Features.CQRS.Results.OrderDetailResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Dtos.OrderDetailDtos;
using OrderApi.Domain.Dtos.OrderDtos;
using OrderApi.Domain.Dtos.ProductDtos;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.CQRS.Handler.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<Domain.Entities.Product> _productRepository;
        private readonly IRepository<Order> _orderRepository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> orderDetailRepository, IRepository<Domain.Entities.Product> productRepository, IRepository<Order> orderRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery getOrderDetailByIdQuery)
        {
            var values = await _orderDetailRepository.GetByIdAsync(getOrderDetailByIdQuery.Id);
            
            if (values != null)
            {
                values.Product = await _productRepository.GetByIdAsync(values.ProductId);
                values.Order = await _orderRepository.GetByIdAsync(values.OrderId);

                return new GetOrderDetailByIdQueryResult
                {
                    OrderDetailId = values.OrderDetailId,
                    ProductId = values.ProductId,
                    Product = new Product
                    {
                        ProductId = values.ProductId,
                        ProductName = values.Product.ProductName,
                        ProductPrice= values.Product.ProductPrice,
                    },
                    ProductAmount = values.ProductAmount,
                    OrderId = values.OrderId,
                    Order = new GetOrderByOrderDetailDto
                    {
                        OrderId= values.OrderId, 
                        OrderDate= values.Order.OrderDate,
                        AddressId= values.Order.AddressId,   
                        UserId = values.Order.UserId    
                    }
                };
            }
            throw new NotFoundIdException(getOrderDetailByIdQuery.Id);

        }
    }
}
