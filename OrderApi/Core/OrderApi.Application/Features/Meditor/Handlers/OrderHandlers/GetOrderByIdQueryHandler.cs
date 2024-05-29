using MediatR;
using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.Meditor.Queries.OrderQueries;
using OrderApi.Application.Features.Meditor.Results.OrderResults;
using OrderApi.Application.Interfaces;
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

            var orderAddressValue = await _addressRepository.GetByIdAsync(values.AddressId);   
            
            var orderUserValue = await _userRepository.GetByIdAsync(values.UserId);

            var orderDetailByOrderIdList = await _orderDetailRepository.GetByIdListAsync(values.OrderId);

            values.Address= orderAddressValue;
            values.User= orderUserValue;

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
