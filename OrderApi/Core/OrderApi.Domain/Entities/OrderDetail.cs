﻿namespace OrderApi.Domain.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public int ProductTotalPrice { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}