using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.HttpModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Main.Services.Interfaces
{
    public interface IMerchService
    {
        Task CreateMerchRequest(RequestMerchModel model, CancellationToken token);

        Task<List<SingleMerchModel>> GetInfoAboutMerchGiving(CancellationToken token);
    }
}
