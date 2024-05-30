using OrderApi.Domain.Dtos.AddressDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrderApi.Application.Features.Meditor.Results.UserResults
{
    public class GetUserQueryResult
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<GetAddressByUserDto> Addresses { get; set; }

    }
}
