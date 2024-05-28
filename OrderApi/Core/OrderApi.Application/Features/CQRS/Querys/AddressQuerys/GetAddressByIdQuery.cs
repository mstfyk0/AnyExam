using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Application.Features.CQRS.Querys.AddressQuerys
{
    public class GetAddressByIdQuery
    {
        public int Id { get; set; }

        public GetAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}
