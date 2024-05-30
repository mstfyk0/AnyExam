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


namespace OrderApi.Application.Features.Meditor.Handlers.OrderHandlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdQueryResult>
    {

        private readonly IRepository<GetOrderDto> _orderRepository;
        private readonly IRepository<GetUserByOrderDto> _userRepository;
        private readonly IRepository<GetAddressByOrderDto> _addressRepository;
        private readonly IRepository<GetOrderDetailByOrderDto> _orderDetailRepository;


        public GetOrderByIdQueryHandler(IRepository<GetOrderDto> repository, IRepository<GetUserByOrderDto> userRepository, IRepository<GetAddressByOrderDto> addressRepository, IRepository<GetOrderDetailByOrderDto> orderDetailRepository)
        {
            _orderRepository = repository;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<GetOrderByIdQueryResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _orderRepository.GetByIdAsync(request.Id);

            var orderDetailByOrderIdList = await _orderDetailRepository.GetByIdListAsync("OrderId",values.OrderId);

            values.Address = await _addressRepository.GetByIdAsync(values.AddressId);
            values.User = await _userRepository.GetByIdAsync(values.UserId);

            foreach (var item in orderDetailByOrderIdList)
            {
                values.OrderDetails.Add(item);  
            }

            if (values != null)
            {
                return new GetOrderByIdQueryResult
                {
                    OrderDate = values.OrderDate,
                    OrderId = values.OrderId,
                    AddressId = values.AddressId,
                    UserId = values.UserId,
                    Address= values.Address,
                    User=values.User,
                    OrderDetails= values.OrderDetails,
                };
            }
            throw new NotFoundIdException(request.Id);
        }
    }
}
