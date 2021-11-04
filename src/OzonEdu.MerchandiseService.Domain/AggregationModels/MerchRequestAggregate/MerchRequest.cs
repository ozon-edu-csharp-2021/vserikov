using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class MerchRequest : Entity
    {
        public RequestNumber RequestNumber { get; private set; }

        public RequestStatus RequestStatus { get; private set; }

        public MerchItem Item { get; }

        public MerchRequest(RequestNumber requestNumber, RequestStatus requestStatus, MerchItem item)
        {
            RequestNumber = requestNumber;
            RequestStatus = requestStatus;
            Item = item;
        }

        public void SetRequestNumber(RequestNumber number)
        {
            RequestNumber = number;
        }

        public void ChangeStatus(RequestStatus status)
        {
            if (RequestStatus.Equals(RequestStatus.Done) || RequestStatus.Equals(RequestStatus.Error))
                throw new MerchRequestStatusException($"Request is completed. Status changes unavailable");
            RequestStatus = status;
        }
    }
}
