using MediatR;
using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.Meditor.Queries.UserQueries;
using OrderApi.Application.Features.Meditor.Results.UserResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Dtos.AddressDtos;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.UserHandlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {

        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Address> _addressRepository;

        public GetUserByIdQueryHandler(IRepository<User> userRepository, IRepository<Address> addressRepository)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
        }

        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _userRepository.GetByIdAsync(request.Id);

            if (values != null)
            {
                values.Addresses = await _addressRepository.GetByIdListAsync("UserId", values.UserId);

                return new GetUserByIdQueryResult
                {
                    UserId = values.UserId,
                    UserName = values.UserName,
                    Password = values.Password,
                    Addresses= values.Addresses.Select(address=> new GetAddressByUserDto
                    {
                        AddressId=address.AddressId,
                        City=address.City,
                        Detail=address.Detail,
                        District=address.District,
                        UserId = address.UserId 
                    }).ToList() 
                };
            }
            throw new NotFoundIdException(request.Id);
        }
    }
}
