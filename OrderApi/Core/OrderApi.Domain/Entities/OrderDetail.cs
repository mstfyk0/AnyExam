namespace OrderApi.Domain.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }  
        public List<Product> Products { get; set; } 
        public int ProductAmount { get; set; }
        public decimal ProductTotalPrice { get => Products.FirstOrDefault().ProductPrice * ProductAmount; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
