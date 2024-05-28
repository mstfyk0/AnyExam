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
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery getAddressByIdQuery)
        {
            var values = await _repository.GetByIdAsync(getAddressByIdQuery.Id);

            if(values != null)
            {

                return new GetAddressByIdQueryResult
                {
                    AddressId = values.AddressId,
                    City = values.City,
                    District = values.District,
                    Detail = values.Detail,
                    UserId = values.UserId,
                };
            }
            throw new NotFoundIdException();
        }
    }
}
