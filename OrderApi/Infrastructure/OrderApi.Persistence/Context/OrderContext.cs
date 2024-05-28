using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderApi.Domain.Entities;


namespace OrderApi.Persistence.Context
{
    public class OrderContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public OrderContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SQLConnection"));
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orderings { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }

}
