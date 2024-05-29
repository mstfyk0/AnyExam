using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.CQRS.Querys.AddressQuerys;
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
    public class GetAddressByUserIdQueryHandler
    {
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<User> _userRepository;

        public GetAddressByUserIdQueryHandler(IRepository<Address> addressRepository, IRepository<User> userRepository)
        {
            _addressRepository = addressRepository;
            _userRepository = userRepository;
        }

        public async Task<GetAddressByUserIdQueryResult> Handle(GetAddressByUserIdQuery getAddressByIdQuery)
        {
            var values = await _addressRepository.GetByIdAsync(getAddressByIdQuery.Id);
            var userValues = await _userRepository.GetByIdAsync(values.UserId);

            values.User = userValues;    

            if(values != null)
            {

                return new GetAddressByUserIdQueryResult
                {
                    AddressId = values.AddressId,
                    City = values.City,
                    District = values.District,
                    Detail = values.Detail,
                    UserId = values.UserId,
                };
            }
            throw new NotFoundIdException(getAddressByIdQuery.Id);
        }
    }
}
