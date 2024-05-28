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

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            var values = await _repository.GetByIdAsync(updateOrderDetailCommand.OrderDetailId);

            values.ProductTotalPrice = updateOrderDetailCommand.ProductTotalPrice;
            values.ProductPrice = updateOrderDetailCommand.ProductPrice;
            values.ProductName = updateOrderDetailCommand.ProductName;
            values.ProductId = updateOrderDetailCommand.ProductId;
            values.OrderId = updateOrderDetailCommand.OrderId;
            values.ProductAmount = updateOrderDetailCommand.ProductAmount;
            await _repository.UpdateAsync(values);
        }
    }
}
