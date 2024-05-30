namespace OrderApi.Domain.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }  
        public int ProductAmount { get; set; }
        public int OrderId { get; set; }
    }
}
