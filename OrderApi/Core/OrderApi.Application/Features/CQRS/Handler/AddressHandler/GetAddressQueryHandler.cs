using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.CQRS.Results.AddressResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            foreach (var value in values)
            {
                value.User = await _userRepository.GetByIdAsync(value.UserId);
            }

            if (values != null)
            {
                return values.Select(x => new GetAddressQueryResult
                {
                    AddressId = x.AddressId,
                    City = x.City,
                    Detail = x.Detail,
                    District = x.District,
                    UserId = x.UserId,
                    User = x.User 

            }).ToList();

            }
            throw new NotFoundException();
        }
    }
}
