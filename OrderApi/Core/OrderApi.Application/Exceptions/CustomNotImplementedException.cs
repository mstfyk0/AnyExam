using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Application.Exceptions
{
    public class CustomNotImplementedException : Exception
    {
        public CustomNotImplementedException()
        : base($"Kayıt etmek istediğiniz kullanıcı zaten kayıtlıdır.")
        {
        }
    }
}
