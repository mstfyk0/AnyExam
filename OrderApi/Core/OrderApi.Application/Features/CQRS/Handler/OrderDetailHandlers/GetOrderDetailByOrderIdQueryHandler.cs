using OrderApi.Application.Exceptions;
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
    public class GetOrderDetailByOrderIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<Product> _productRepository;

        public GetOrderDetailByOrderIdQueryHandler(IRepository<OrderDetail> orderDetailRepository, IRepository<Product> productRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }

        public async Task<List<GetOrderDetailByOrderIdQueryResult>> Handle(GetOrderDetailByOrderIdQuery getOrderDetailByIdQuery)
        {
            var values = await _orderDetailRepository.GetByIdListAsync("Id" ,getOrderDetailByIdQuery.Id);

            if (values != null)
            {
                List<Product> productList = new List<Product>();

                foreach (var value in values)
                {
                    productList.Add(await _productRepository.GetByIdAsync(value.ProductId));
                }
                return values.Select(x => new GetOrderDetailByOrderIdQueryResult
                {
                    ProductId = x.ProductId,
                    Products= productList,
                    ProductAmount = x.ProductAmount,
                    OrderId = x.OrderId,
                    OrderDetailId = x.OrderDetailId,
                }).ToList();
            }
            throw new NotFoundIdException(getOrderDetailByIdQuery.Id);

        }
    }
}
