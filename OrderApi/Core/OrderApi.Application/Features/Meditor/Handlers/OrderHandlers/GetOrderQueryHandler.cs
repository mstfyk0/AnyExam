using MediatR;
using MediatR.NotificationPublishers;
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

        private readonly IRepository<GetOrderDto> _orderRepository;
        private readonly IRepository<GetUserByOrderDto> _userRepository;
        private readonly IRepository<GetAddressByOrderDto> _addressRepository;
        private readonly IRepository<GetOrderDetailByOrderDto> _orderDetailRepository;

        public GetOrderQueryHandler(IRepository<GetOrderDto> repository, IRepository<GetUserByOrderDto> userRepository, IRepository<GetAddressByOrderDto> addressRepository, IRepository<GetOrderDetailByOrderDto> orderDetailRepository)
        {
            _orderRepository = repository;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<GetOrderQueryResult>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var values = await _orderRepository.GetAllAsync();

            foreach (var value in values)
            {
                value.Address = await _addressRepository.GetByIdAsync(value.AddressId);
                value.User = await _userRepository.GetByIdAsync(value.UserId);
                value.OrderDetails = await _orderDetailRepository.GetByIdListAsync("OrderId",value.OrderId);
            }

            if (values != null)
            {

                return values.Select(x => new GetOrderQueryResult
                {
                    OrderDate = x.OrderDate,
                    OrderId = x.OrderId,
                    AddressId = x.AddressId,
                    Address = x.Address,
                    OrderDetails = x.OrderDetails,
                    UserId=x.UserId,
                    User=x.User,    
                }).ToList();
            }
            throw new NotFoundException();

        }
    }
}
