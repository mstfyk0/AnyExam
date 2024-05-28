using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        : base($"Kayıt bulunmamaktadır.")
        {
        }
    }
}
