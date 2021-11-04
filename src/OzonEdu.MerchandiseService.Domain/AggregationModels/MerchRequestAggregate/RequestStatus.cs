using OzonEdu.MerchandiseService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class RequestStatus : Enumeration
    {
        public static RequestStatus Queue = new(1, nameof(Queue));

        public static RequestStatus Progress = new(2, nameof(Progress));

        public static RequestStatus Done = new(3, nameof(Done));

        public static RequestStatus Error = new(4, nameof(Error));

        public RequestStatus(int id, string name) : base(id, name)
        {
        }
    }
}
