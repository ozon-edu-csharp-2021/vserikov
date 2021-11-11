using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Models;
using OzonEdu.MerchandiseService.Infrastructure.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    internal class GetMerchGivingInfoHandler : IRequestHandler<GetMerchGivingInfoQuery, MerchGivingInfoResponse>
    {
        private readonly IMerchItemRepository _repository;

        public GetMerchGivingInfoHandler(IMerchItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<MerchGivingInfoResponse> Handle(GetMerchGivingInfoQuery request, CancellationToken cancellationToken)
            => new MerchGivingInfoResponse() { MerchItems = await _repository.GetAllAsync(cancellationToken) };
    }
}
