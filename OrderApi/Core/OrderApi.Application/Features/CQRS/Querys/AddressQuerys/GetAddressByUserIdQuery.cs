using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Application.Features.CQRS.Querys.AddressQuerys
{
    public class GetAddressByUserIdQuery
    {
        public int Id { get; set; }

        public GetAddressByUserIdQuery(int id)
        {
            Id = id;
        }
    }
}
