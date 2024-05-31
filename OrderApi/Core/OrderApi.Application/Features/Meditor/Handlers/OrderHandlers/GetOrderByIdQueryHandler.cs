using MediatR;
using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.Meditor.Queries.OrderQueries;
using OrderApi.Application.Features.Meditor.Results.OrderResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Dtos.AddressDtos;
using OrderApi.Domain.Dtos.OrderDetailDtos;
using OrderApi.Domain.Dtos.UserDtos;
using OrderApi.Domain.Entities;
using System.Net.Http.Headers;


namespace OrderApi.Application.Features.Meditor.Handlers.OrderHandlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdQueryResult>
    {

        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<Product> _productRepository;


        public GetOrderByIdQueryHandler(IRepository<Order> repository, IRepository<User> userRepository, IRepository<Address> addressRepository, IRepository<OrderDetail> orderDetailRepository, IRepository<Product> productRepository)
        {
            _orderRepository = repository;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }

        public async Task<GetOrderByIdQueryResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _orderRepository.GetByIdAsync(request.Id);

            if (values != null)
            {
                GetOrderByIdQueryResult getOrderByIdQueryResult;    
                var orderDetailByOrderIdList = await _orderDetailRepository.GetByIdListAsync("OrderId", values.OrderId);

                values.Address = await _addressRepository.GetByIdAsync(values.AddressId);
                values.User = await _userRepository.GetByIdAsync(values.UserId);

                getOrderByIdQueryResult = new GetOrderByIdQueryResult()
                {
                    OrderDate = values.OrderDate,
                    OrderId = values.OrderId,
                    AddressId = values.AddressId,
                    UserId = values.UserId,
                    Address = new GetAddressByOrderDto
                    {
                        UserId = values.UserId,
                        AddressId = values.AddressId,
                        City = values.Address.City,
                        Detail = values.Address.Detail,
                        District = values.Address.District
                    },
                    User = new GetUserByOrderDto
                    {
                        UserId = values.UserId,
                        UserName = values.User.UserName

                    }
                };
                
                if (orderDetailByOrderIdList.Count > 0)
                {
                    foreach (var product in values.OrderDetails)
                    {
                        product.Product = await _productRepository.GetByIdAsync(product.ProductId);
                    }
                    getOrderByIdQueryResult.OrderDetails = values.OrderDetails.Select(orderdetail => new GetOrderDetailByOrderDto
                    {
                        OrderId = orderdetail.OrderId,
                        Product = orderdetail.Product,
                        ProductAmount = orderdetail.ProductAmount,
                        ProductId = orderdetail.ProductId,
                        OrderDetailId = orderdetail.OrderDetailId

                    }).ToList();
                }
                else
                {
                    getOrderByIdQueryResult.OrderDetails = null;
                }

                return getOrderByIdQueryResult;
            }
            throw new NotFoundIdException(request.Id);
        }
    }
}
