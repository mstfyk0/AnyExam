using OrderApi.Domain.Dtos.OrderDtos;
using OrderApi.Domain.Dtos.ProductDtos;
using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Domain.Dtos.OrderDetailDtos
{
    public record GetOrderDetailDto
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public int ProductAmount { get; set; }
        public int OrderId { get; set; }
        public GetProductByOrderDetailDto Product { get; set; }
        public decimal ProductTotalPrice { get => Product.ProductPrice * ProductAmount; }
        public GetOrderByOrderDetailDto Order { get; set; }
    }
}
