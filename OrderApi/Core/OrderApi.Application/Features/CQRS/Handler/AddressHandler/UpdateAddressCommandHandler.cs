﻿using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.CQRS.Commands.AddressCommands;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;


namespace OrderApi.Application.Features.CQRS.Handler.AddressHandler
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IUnitOfWork _unitOfWork;


        public UpdateAddressCommandHandler(IRepository<Address> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var values = await _repository.GetByIdAsync(updateAddressCommand.AddressId);
            if (values != null)
            {
                values.Detail = updateAddressCommand.Detail;
                values.District = updateAddressCommand.District;
                values.City = updateAddressCommand.City;
                values.UserId = updateAddressCommand.UserId;
                _repository.Update(values);
                await _unitOfWork.Commit();
            }
            else
            {
                throw new NotFoundIdException(updateAddressCommand.AddressId);
            }
        }
    }
}
