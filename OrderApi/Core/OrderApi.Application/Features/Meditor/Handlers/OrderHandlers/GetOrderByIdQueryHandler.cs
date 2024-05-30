using MediatR;
using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.Meditor.Queries.OrderQueries;
using OrderApi.Application.Features.Meditor.Results.OrderResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Dtos.AddressDtos;
using OrderApi.Domain.Dtos.OrderDetailDtos;
using OrderApi.Domain.Dtos.UserDtos;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.OrderHandlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdQueryResult>
    {

        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;


        public GetOrderByIdQueryHandler(IRepository<Order> repository, IRepository<User> userRepository, IRepository<Address> addressRepository, IRepository<OrderDetail> orderDetailRepository)
        {
            _orderRepository = repository;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<GetOrderByIdQueryResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _orderRepository.GetByIdAsync(request.Id);

            if (values != null)
            {

                var orderDetailByOrderIdList = await _orderDetailRepository.GetByIdListAsync("OrderId", values.OrderId);

                values.Address = await _addressRepository.GetByIdAsync(values.AddressId);
                values.User = await _userRepository.GetByIdAsync(values.UserId);

                foreach (var item in orderDetailByOrderIdList)
                {
                    values.OrderDetails.Add(item);
                }
                return new GetOrderByIdQueryResult
                {
                    OrderDate = values.OrderDate,
                    OrderId = values.OrderId,
                    AddressId = values.AddressId,
                    UserId = values.UserId,
                    Address = new GetAddressByOrderDto
                    {
                        UserId = values.UserId,
                        AddressId = values.AddressId,
                        City=values.Address.City,
                        Detail=values.Address.Detail,
                        District = values.Address.District
                    } ,
                    User = new GetUserByOrderDto
                    {
                        UserId = values.UserId,
                        UserName = values.User.UserName

                    },
                    OrderDetails= values.OrderDetails.Select(orderdetail=> new GetOrderDetailByOrderDto
                    {
                        OrderId = orderdetail.OrderId,   
                        Product = orderdetail.Product,
                        ProductAmount = orderdetail.ProductAmount,
                        ProductId = orderdetail.ProductId,
                        OrderDetailId = orderdetail.OrderDetailId   
                        
                    } ).ToList() ,
                };
            }
            throw new NotFoundIdException(request.Id);
        }
    }
}
