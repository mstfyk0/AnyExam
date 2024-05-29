using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Application.Features.CQRS.Results.OrderDetailResults
{
    public class GetOrderDetailQueryResult
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductTotalPrice { get => Product.ProductPrice * ProductAmount; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
