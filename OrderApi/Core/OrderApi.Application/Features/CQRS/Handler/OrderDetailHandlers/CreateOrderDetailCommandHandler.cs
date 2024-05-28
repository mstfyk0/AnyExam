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
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IUnitOfWork _unitOfWork;


        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository, IUnitOfWork unitOfWork)
        {
            _orderDetailRepository = orderDetailRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateOrderDetailCommand createOrderDetailCommand)
        {
            _orderDetailRepository.Create(new OrderDetail
            {
                ProductAmount = createOrderDetailCommand.ProductAmount,
                ProductId = createOrderDetailCommand.ProductId,
                ProductName = createOrderDetailCommand.ProductName,
                ProductPrice = createOrderDetailCommand.ProductPrice,
                ProductTotalPrice = createOrderDetailCommand.ProductTotalPrice,
                OrderId = createOrderDetailCommand.OrderId,
            });
            await _unitOfWork.Commit();

        }
    }
}
