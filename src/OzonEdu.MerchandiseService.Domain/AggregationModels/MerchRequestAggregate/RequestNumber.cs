using OzonEdu.MerchandiseService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class RequestNumber : Entity
    {
        public long Value { get; }

        public RequestNumber(long value)
        {
            Value = value;
        }
    }
}
