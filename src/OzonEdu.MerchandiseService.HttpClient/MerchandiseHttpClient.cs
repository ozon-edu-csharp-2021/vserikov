using OzonEdu.MerchandiseService.HttpClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClient
{
    public class MerchandiseHttpClient : IMerchandiseHttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public MerchandiseHttpClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SingleMerchModel>> GetMerchInfo(CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("v1/api/merchandise", token);
            var body = await response.Content.ReadAsStringAsync(token);

            return JsonSerializer.Deserialize<List<SingleMerchModel>>(body);
        }
    }
}
