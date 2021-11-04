using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Domain.Exceptions
{
    class MerchRequestStatusException : Exception
    {
        public MerchRequestStatusException(string message) : base(message)
        {
        }

        public MerchRequestStatusException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
