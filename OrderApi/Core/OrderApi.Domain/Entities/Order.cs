

namespace OrderApi.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public decimal TotalPrice { get => OrderDetails?.Sum(p => p.ProductTotalPrice) ?? 0; }
        public User User { get; set; }
        public Address Address { get; set; }
    }
}
