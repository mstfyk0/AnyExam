using MediatR;
using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.Meditor.Queries.OrderQueries;
using OrderApi.Application.Features.Meditor.Results.UserResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Dtos.AddressDtos;
using OrderApi.Domain.Dtos.UserDtos;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.Meditor.Handlers.UserHandlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<GetUserQueryResult>>
    {

        private readonly IRepository<GetUserDto> _userRepository;
        private readonly IRepository<GetAddressByUserDto> _addressRepository;

        public GetUserQueryHandler(IRepository<GetUserDto> userRepository, IRepository<GetAddressByUserDto> addressRepository)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
        }

        public async Task<List<GetUserQueryResult>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var values = await _userRepository.GetAllAsync();
            foreach (var value in values) 
            {
                value.Addresses = await _addressRepository.GetByIdListAsync("UserId",value.UserId);
            }
            if (values != null)
            {

                return values.Select(x => new GetUserQueryResult
                {
                    UserId = x.UserId,
                    UserName = x.UserName,
                    Password=x.Password,
                    Addresses = x.Addresses
                }).ToList();
            }
            throw new NotFoundException();

        }
    }
}
