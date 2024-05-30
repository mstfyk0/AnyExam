using OrderApi.Domain.Dtos.UserDtos;
using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.CQRS.Results.AddressResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.CQRS.Handler.AddressHandler
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IRepository<User> _userRepository;

        public GetAddressQueryHandler(IRepository<Address> repository, IRepository<User> userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }
        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();

            if (values != null)
            {
                foreach (var value in values)
                {
                    value.User = await _userRepository.GetByIdAsync((int)value.UserId);

                }
                return values.Select(x => new GetAddressQueryResult
                {
                    AddressId = x.AddressId,
                    City = x.City,
                    Detail = x.Detail,
                    District = x.District,
                    UserId = (int)x.UserId,
                    User = new GetUserByAddressDto
                    {
                        UserName = x.User.UserName,
                        UserId = x.User.UserId
                    }

                }).ToList();

            }
            throw new NotFoundException();
        }
    }
}
