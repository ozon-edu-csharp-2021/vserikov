using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class Pack : Entity
    {
        public PackType Type { get; }

        public Pack(PackType type)
        {
            Type = type;
        }
    }
}
