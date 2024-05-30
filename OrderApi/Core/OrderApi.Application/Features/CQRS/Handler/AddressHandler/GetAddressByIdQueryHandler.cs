using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.CQRS.Querys.AddressQuerys;
using OrderApi.Application.Features.CQRS.Results.AddressResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Dtos.AddressDtos;
using OrderApi.Domain.Dtos.UserDtos;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.CQRS.Handler.AddressHandler
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IRepository<User> _userRepository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository, IRepository<User> userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery getAddressByIdQuery)
        {
            var values = await _repository.GetByIdAsync(getAddressByIdQuery.Id);
            
            if(values != null)
            {
                var userValues = await _userRepository.GetByIdAsync((int)values.UserId);

                values.User = userValues;

                return new GetAddressByIdQueryResult
                {
                    AddressId = values.AddressId,
                    City = values.City,
                    District = values.District,
                    Detail = values.Detail,
                    UserId = (int)values.UserId,
                    User = new GetUserByAddressDto
                    {
                        UserId = (int)values.UserId,
                        UserName = values.User.UserName
                    }
                };
            }
            throw new NotFoundIdException(getAddressByIdQuery.Id);
        }
    }
}
