using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Application.Features.CQRS.Querys.OrderDetailQuerys
{
    public class GetOrderDetailByOrderIdQuery
    {
        public int Id { get; set; }

        public GetOrderDetailByOrderIdQuery(int id)
        {
            Id = id;
        }
    }
}
