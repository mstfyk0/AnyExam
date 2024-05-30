using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Domain.Dtos.UserDtos
{
    public record GetUserByOrderDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
