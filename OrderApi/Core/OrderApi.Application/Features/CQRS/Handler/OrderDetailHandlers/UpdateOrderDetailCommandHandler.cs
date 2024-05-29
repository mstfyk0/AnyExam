using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.CQRS.Commands.OrderDetailCommands;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Application.Features.CQRS.Handler.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IUnitOfWork _unitOfWork;


        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            var values = await _repository.GetByIdAsync(updateOrderDetailCommand.OrderDetailId);

            if (values != null)
            {
                values.ProductId = updateOrderDetailCommand.ProductId;
                values.OrderId = updateOrderDetailCommand.OrderId;
                values.ProductAmount = updateOrderDetailCommand.ProductAmount;
                _repository.Update(values);
                await _unitOfWork.Commit();
            }
            else
            {
                throw new NotFoundIdException(updateOrderDetailCommand.OrderDetailId);
            }
        }
    }
}
