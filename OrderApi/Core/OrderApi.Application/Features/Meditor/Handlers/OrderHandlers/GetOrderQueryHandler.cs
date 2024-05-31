using MediatR;
using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.Meditor.Queries.OrderQueries;
using OrderApi.Application.Features.Meditor.Results.OrderResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Dtos.AddressDtos;
using OrderApi.Domain.Dtos.OrderDetailDtos;
using OrderApi.Domain.Dtos.OrderDtos;
using OrderApi.Domain.Dtos.UserDtos;
using OrderApi.Domain.Entities;
using System.ComponentModel.DataAnnotations;


namespace OrderApi.Application.Features.Meditor.Handlers.OrderHandlers
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, List<GetOrderQueryResult>>
    {

        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<Product> _productRepository;

        public GetOrderQueryHandler(IRepository<Order> repository, IRepository<User> userRepository, IRepository<Address> addressRepository, IRepository<OrderDetail> orderDetailRepository, IRepository<Product> productRepository)
        {
            _orderRepository = repository;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }

        public async Task<List<GetOrderQueryResult>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var values = await _orderRepository.GetAllAsync();
            
            if (values != null)
            {
                foreach (var value in values)
                {
                    value.Address = await _addressRepository.GetByIdAsync(value.AddressId);
                    value.User = await _userRepository.GetByIdAsync(value.UserId);
                    value.OrderDetails = await _orderDetailRepository.GetByIdListAsync("OrderId", value.OrderId);
                    foreach (var item in value.OrderDetails)
                    {
                        item.Product= await _productRepository.GetByIdAsync(item.ProductId);
                    }
                }

                return values.Select(x => new GetOrderQueryResult
                {
                    OrderDate = x.OrderDate,
                    OrderId = x.OrderId,
                    AddressId = x.AddressId,
                    Address = new GetAddressByOrderDto
                    {
                        UserId = x.UserId,
                        AddressId= x.AddressId,
                        City=x.Address.City,
                        Detail  =x.Address.Detail,
                        District= x.Address.District    
                    } ,
                    OrderDetails = x.OrderDetails.Select( orderDetail=> new GetOrderDetailByOrderDto
                    {
                        OrderId = orderDetail.OrderId,
                        ProductId = orderDetail.ProductId,
                        Product=orderDetail.Product,
                        ProductAmount = orderDetail.ProductAmount,
                        OrderDetailId = orderDetail.OrderDetailId
                        
                    }).ToList() ,
                    UserId=x.UserId,
                    User= new GetUserByOrderDto {
                        UserId = x.UserId,
                        UserName = x.User.UserName
                    }    
                }).ToList();
            }
            throw new NotFoundException();

        }
    }
}
