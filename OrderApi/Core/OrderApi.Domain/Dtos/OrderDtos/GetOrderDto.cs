using OrderApi.Domain.Dtos.AddressDtos;
using OrderApi.Domain.Dtos.OrderDetailDtos;
using OrderApi.Domain.Dtos.UserDtos;


namespace OrderApi.Domain.Dtos.OrderDtos
{
    public record GetOrderDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<GetOrderDetailByOrderDto> OrderDetails { get; set; }
        public decimal TotalPrice { get => OrderDetails?.Sum(p => p.ProductTotalPrice) ?? 0; }
        public GetUserByOrderDto User { get; set; }
        public GetAddressByOrderDto Address { get; set; }
    }
}
