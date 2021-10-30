using OzonEdu.MerchandiseService.HttpModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.HttpClient.Interfaces
{
    public interface IMerchandiseHttpClient
    {
        Task RequestMerch(RequestMerchModel request, CancellationToken token);

        Task<List<SingleMerchModel>> GetMerchInfo(CancellationToken token);
    }
}
