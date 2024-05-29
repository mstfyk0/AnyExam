﻿using OrderApi.Application.Exceptions;
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
            var userValues = await _userRepository.GetByIdAsync(values.UserId);

            values.User = userValues;    

            if(values != null)
            {

                return new GetAddressByIdQueryResult
                {
                    AddressId = values.AddressId,
                    City = values.City,
                    District = values.District,
                    Detail = values.Detail,
                    UserId = values.UserId,
                    User = values.User,

                };
            }
            throw new NotFoundIdException(getAddressByIdQuery.Id);
        }
    }
}
