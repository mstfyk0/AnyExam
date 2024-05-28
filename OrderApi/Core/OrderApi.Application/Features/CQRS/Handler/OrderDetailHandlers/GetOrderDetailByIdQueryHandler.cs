using OrderApi.Application.Features.CQRS.Querys.OrderDetailQuerys;
using OrderApi.Application.Features.CQRS.Results.OrderDetailResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Application.Features.CQRS.Handler.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery getOrderDetailByIdQuery)
        {
            var values = await _repository.GetByIdAsync(getOrderDetailByIdQuery.Id);
            return new GetOrderDetailByIdQueryResult
            {
                ProductAmount = values.ProductAmount,
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                ProductPrice = values.ProductPrice,
                ProductTotalPrice = values.ProductTotalPrice,
                OrderId = values.OrderId,
                OrderDetailId = values.OrderDetailId,
            };
        }
    }
}
