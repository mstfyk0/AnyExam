using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Application.Features.Meditor.Command.ProductCommands
{
    public class CreateProductCommand : IRequest
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
