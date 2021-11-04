using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Domain.Exceptions
{
    public class UnknownPackTypeException : Exception
    {
        public UnknownPackTypeException(string message) : base(message)
        {
        }

        public UnknownPackTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
