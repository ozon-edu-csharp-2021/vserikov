using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands
{
    public class CreateMerchRequestCommand : IRequest
    {
        public Employee Sender { get; set; }
        public Employee Reciever { get; set; }
        public Pack Pack { get; set; }
        public Quantity Quantity { get; set; }

        public CreateMerchRequestCommand(int senderId, int recieverId, int packId, int quantity)
        {
            Sender = new Employee(senderId);
            Reciever = new Employee(recieverId);
            Pack = new Pack(PackType.DefaultPack.GetPackTypeById(packId));
            Quantity = new Quantity(quantity);
        }
    }
}
