using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure.Queries
{
    public class GetMerchGivingInfoQuery : IRequest<List<MerchItem>>
    {
    }
}
