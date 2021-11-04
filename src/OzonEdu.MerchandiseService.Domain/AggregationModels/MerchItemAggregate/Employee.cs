using OzonEdu.MerchandiseService.Domain.Models;
using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class Employee : Entity
    {
        public List<Pack> Packs { get; } = new List<Pack>();

        public Employee(int id)
        {
            Id = id;
        }

        public bool HasPackAlready(Pack pack)
        {
            return Packs.Contains(pack);
        }

        public void AddPack(Pack pack)
        {
            Packs.Add(pack);
        }
    }
}
