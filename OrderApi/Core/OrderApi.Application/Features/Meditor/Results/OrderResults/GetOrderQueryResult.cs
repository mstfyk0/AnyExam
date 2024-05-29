using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrderApi.Application.Features.Meditor.Results.OrderResults
{
    public class GetOrderQueryResult
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public decimal TotalPrice { get => OrderDetails?.Sum(p => p.ProductTotalPrice) ?? 0; }
        public DateTime OrderDate { get; set; }
        public User User { get; set; }
        public Address Address { get; set; }
    }
}
