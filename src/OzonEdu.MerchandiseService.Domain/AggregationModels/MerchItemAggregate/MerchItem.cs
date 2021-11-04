using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.Models;

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
            Sender = sender;
            Reciever = reciever;
            Pack = pack;
            SetQuantity(quantity);
        }

        private void SetQuantity(Quantity quantity)
        {
            if (quantity.Value <= 0)
                throw new IncorrectQuantityException($"Value {nameof(quantity.Value)} is negative");
            Quantity = quantity;
        }
    }
}
