using OrderApi.Application.Exceptions;
using OrderApi.Application.Features.CQRS.Querys.OrderDetailQuerys;
using OrderApi.Application.Features.CQRS.Results.OrderDetailResults;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Dtos.OrderDetailDtos;
using OrderApi.Domain.Dtos.OrderDtos;
using OrderApi.Domain.Dtos.ProductDtos;
using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Application.Features.CQRS.Handler.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<GetOrderDetailDto> _orderDetailRepository;
        private readonly IRepository<GetProductByOrderDetailDto> _productRepository;
        private readonly IRepository<GetOrderByOrderDetailDto> _orderRepository;

        public GetOrderDetailByIdQueryHandler(IRepository<GetOrderDetailDto> orderDetailRepository, IRepository<GetProductByOrderDetailDto> productRepository, IRepository<GetOrderByOrderDetailDto> orderRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery getOrderDetailByIdQuery)
        {
            var values = await _orderDetailRepository.GetByIdAsync(getOrderDetailByIdQuery.Id);
            values.Product = await _productRepository.GetByIdAsync(values.ProductId);
            values.Order = await _orderRepository.GetByIdAsync(values.OrderId);

            if (values != null)
            {

                return new GetOrderDetailByIdQueryResult
                {
                    OrderDetailId = values.OrderDetailId,
                    ProductId = values.ProductId,
                    Product = values.Product,
                    ProductAmount = values.ProductAmount,
                    OrderId = values.OrderId,
                    Order = values.Order
                };
            }
            throw new NotFoundIdException(getOrderDetailByIdQuery.Id);

        }
    }
}
