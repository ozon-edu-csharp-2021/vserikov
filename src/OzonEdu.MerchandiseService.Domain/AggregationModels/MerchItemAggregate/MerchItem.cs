using OzonEdu.MerchandiseService.Domain.Models;
using System;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class MerchItem : Entity
    {
        public Employee Sender { get; }

        public Employee Reciever { get; }

        public Pack Pack { get; }

        public Quantity Quantity { get; private set; }

        public MerchItem(Employee sender, Employee reciever, Pack pack, Quantity quantity)
        {
            if (sender is null || reciever is null || pack is null || quantity is null)
                throw new ArgumentNullException("One or more arguments are null");
            Sender = sender;
            Reciever = reciever;
            Pack = pack;
            Quantity = quantity;
        }
    }
}
