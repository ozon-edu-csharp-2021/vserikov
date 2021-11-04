using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Domain.Exceptions
{
    public class IncorrectQuantityException : Exception
    {
        public IncorrectQuantityException(string message) : base(message)
        {
        }

        public IncorrectQuantityException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
