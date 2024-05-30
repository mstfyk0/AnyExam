using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrderApi.Application.Features.CQRS.Results.OrderDetailResults
{
    public class GetOrderDetailByOrderIdQueryResult
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public List<Product> Products { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductTotalPrice { get => Products.FirstOrDefault().ProductPrice * ProductAmount; }
        public int OrderId { get; set; }
    }
}
