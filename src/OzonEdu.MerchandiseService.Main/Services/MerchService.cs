using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Main.Services.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Main.Services
{
    public class MerchService : IMerchService
    {
        private readonly List<MerchItem> Items = new()
        {
            new MerchItem(new Employee(10), new Employee(24), new Pack(PackType.StarterPack), new Quantity(1)),
            new MerchItem(new Employee(16), new Employee(97), new Pack(PackType.WelcomePack), new Quantity(1)),
            new MerchItem(new Employee(34), new Employee(39), new Pack(PackType.ConferenceSpeakerPack), new Quantity(1)),
            new MerchItem(new Employee(42), new Employee(84), new Pack(PackType.WelcomePack), new Quantity(1)),
            new MerchItem(new Employee(66), new Employee(16), new Pack(PackType.VeteranPack), new Quantity(1))
        };

        public async Task CreateMerchRequest(RequestMerchModel model, CancellationToken _)
        {
            var pack = new Pack(PackType.GetPackTypeById(model.PackId));

            if (GetEmployeeById(model.RecieverId).HasPackAlready(pack))
                throw new RecieverHasPackException("Reciever employee has this pack already");

            var merchItem = new MerchItem(
                new Employee(model.SenderId),
                new Employee(model.RecieverId),
                pack,
                new Quantity(model.Quantity));

            // send request
        }

        public Task<List<MerchItem>> GetInfoAboutMerchGiving(CancellationToken _)
        {
            return Task.FromResult(Items);
        }

        private Employee GetEmployeeById(int id)
        {
            var emp = new Employee(id);
            emp.AddPack(new Pack(PackType.VeteranPack));
            return emp;
        }
    }
}
