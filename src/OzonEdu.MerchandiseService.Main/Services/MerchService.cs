using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Main.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Main.Services
{
    public class MerchService : IMerchService
    {
        private readonly List<SingleMerchModel> Items = new List<SingleMerchModel>
        {
            new SingleMerchModel() { SenderId = 52, ReceiverId = 149, MerchType = "Hat", Quantity = 11 },
            new SingleMerchModel() { SenderId = 17, ReceiverId = 261, MerchType = "Pants", Quantity = 4 },
            new SingleMerchModel() { SenderId = 726, ReceiverId = 994, MerchType = "Hat", Quantity = 17 },
            new SingleMerchModel() { SenderId = 151, ReceiverId = 114, MerchType = "Pen", Quantity = 32 },
            new SingleMerchModel() { SenderId = 17, ReceiverId = 773, MerchType = "Tshirt", Quantity = 4 }
        };

        public async Task CreateMerchRequest(RequestMerchModel model, CancellationToken _)
        {
            await Task.Delay(100);
        }

        public Task<List<SingleMerchModel>> GetInfoAboutMerchGiving(CancellationToken _)
        {
            return Task.FromResult(Items);
        }
    }
}
