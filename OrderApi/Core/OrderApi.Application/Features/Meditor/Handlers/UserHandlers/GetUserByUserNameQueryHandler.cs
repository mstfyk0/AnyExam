using MediatR;
using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.Meditor.Queries.UserQueries;
using OrderApi.Application.Features.Meditor.Results.UserResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Dtos.AddressDtos;
using OrderApi.Domain.Dtos.UserDtos;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.UserHandlers
{
    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, GetUserByUserNameQueryResult>
    {

        private readonly IRepository<GetUserDto> _userRepository;
        private readonly IRepository<GetAddressByUserDto> _addressRepository;

        public GetUserByUserNameQueryHandler(IRepository<GetUserDto> userRepository, IRepository<GetAddressByUserDto> addressRepository)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
        }

        public async Task<GetUserByUserNameQueryResult> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            var values = await _userRepository.GetByUserNameAsync(request.UserName);
            values.Addresses = await _addressRepository.GetByIdListAsync("UserId",values.UserId);


            if (values != null)
            {
                return new GetUserByUserNameQueryResult
                {
                    UserId = values.UserId,
                    UserName = values.UserName,
                    Password = values.Password,
                    Addresses = values.Addresses
                };
            }
            throw new NotFoundUserNameException(request.UserName);
        }
    }
}
