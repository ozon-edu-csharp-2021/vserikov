using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class GetMerchGivingInfoHandler : IRequestHandler<GetMerchGivingInfoQuery, List<MerchItem>>
    {
        private readonly IMerchItemRepository _repository;

        public GetMerchGivingInfoHandler(IMerchItemRepository repository)
        {
            _repository = repository;
        }

        public Task<List<MerchItem>> Handle(GetMerchGivingInfoQuery request, CancellationToken cancellationToken)
            => _repository.GetAll(cancellationToken);
    }
}
