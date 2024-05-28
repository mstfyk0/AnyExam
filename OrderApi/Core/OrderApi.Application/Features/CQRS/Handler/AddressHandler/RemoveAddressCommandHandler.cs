using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.CQRS.Commands.AddressCommands;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Application.Features.CQRS.Handler.AddressHandler
{
    public class RemoveAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IUnitOfWork _unitOfWork;


        public RemoveAddressCommandHandler(IRepository<Address> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveAddressCommand removeAddressCommand)
        {
            var value = await _repository.GetByIdAsync(removeAddressCommand.Id);
            
            if (value != null) 
            { 
                _repository.Delete(value);
                await _unitOfWork.Commit();
            }
            else
            {
                throw new NotFoundIdException(removeAddressCommand.Id);
            }

        }
    }
}
