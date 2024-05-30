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
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {

        private readonly IRepository<GetUserDto> _userRepository;
        private readonly IRepository<GetAddressByUserDto> _addressRepository;

        public GetUserByIdQueryHandler(IRepository<GetUserDto> userRepository, IRepository<GetAddressByUserDto> addressRepository)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
        }

        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _userRepository.GetByIdAsync(request.Id);
            values.Addresses = await _addressRepository.GetByIdListAsync("UserId",values.UserId);


            if (values != null)
            {
                return new GetUserByIdQueryResult
                {
                    UserId = values.UserId,
                    UserName = values.UserName,
                    Password = values.Password,
                    Addresses=values.Addresses, 
                };
            }
            throw new NotFoundIdException(request.Id);
        }
    }
}
