using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Domain.Exceptions
{
    public class RecieverHasPackException : Exception
    {
        public RecieverHasPackException(string message) : base(message)
        {
        }

        public RecieverHasPackException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
