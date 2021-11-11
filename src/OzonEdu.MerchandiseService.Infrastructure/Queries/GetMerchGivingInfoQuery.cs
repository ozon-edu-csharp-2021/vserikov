using MediatR;
using OzonEdu.MerchandiseService.Infrastructure.Models;

namespace OzonEdu.MerchandiseService.Infrastructure.Queries
{
    public class GetMerchGivingInfoQuery : IRequest<MerchGivingInfoResponse>
    {
    }
}
