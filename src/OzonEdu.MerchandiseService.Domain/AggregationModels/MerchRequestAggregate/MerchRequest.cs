using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.Models;
using System;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class MerchRequest : Entity
    {
        public RequestNumber RequestNumber { get; }

        public RequestStatus RequestStatus { get; private set; }

        public MerchItem Item { get; }

        public MerchRequest(RequestNumber requestNumber, RequestStatus requestStatus, MerchItem item)
        {
            if (requestNumber is null || requestStatus is null || item is null)
                throw new ArgumentNullException("One or more arguments are null");
            RequestNumber = requestNumber;
            RequestStatus = requestStatus;
            Item = item;
        }

        public MerchRequest(RequestStatus requestStatus, MerchItem item)
        {
            if (requestStatus is null || item is null)
                throw new ArgumentNullException("One or more arguments are null");
            RequestStatus = requestStatus;
            Item = item;
        }

        public void ChangeStatus(RequestStatus status)
        {
            if (RequestStatus.Equals(RequestStatus.Done) || RequestStatus.Equals(RequestStatus.Error))
                throw new MerchRequestStatusException($"Request was completed. Status changes unavailable");
            RequestStatus = status;
        }
    }
}
