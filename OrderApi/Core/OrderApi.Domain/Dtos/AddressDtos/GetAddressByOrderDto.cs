﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Domain.Dtos.AddressDtos
{
    public record GetAddressByOrderDto
    {
        public int AddressId { get; set; }
        public int? UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
