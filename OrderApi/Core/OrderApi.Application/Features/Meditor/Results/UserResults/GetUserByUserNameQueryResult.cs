using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrderApi.Application.Features.Meditor.Results.UserResults
{
    public class GetUserByUserNameQueryResult
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Address> Addresses { get; set; }

    }
}
