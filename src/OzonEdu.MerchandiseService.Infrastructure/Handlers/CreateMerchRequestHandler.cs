using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers
{
    public class CreateMerchRequestHandler : IRequestHandler<CreateMerchRequestCommand>
    {
        private readonly IMerchRequestRepository _repository;

        public CreateMerchRequestHandler(IMerchRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateMerchRequestCommand request, CancellationToken cancellationToken)
        {
            var merchRequest = new MerchRequest(
                null,
                RequestStatus.Queue,
                new MerchItem(request.Sender, request.Reciever, request.Pack, request.Quantity));

            await _repository.CreateAsync(merchRequest, cancellationToken);
            await _repository.WorkUnit.SaveEntitiesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
