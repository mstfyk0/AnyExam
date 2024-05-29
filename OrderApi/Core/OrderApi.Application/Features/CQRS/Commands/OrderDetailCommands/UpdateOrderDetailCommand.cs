using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class UpdateOrderDetailCommand
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public int ProductAmount { get; set; }
        public int OrderId { get; set; }
    }
}
