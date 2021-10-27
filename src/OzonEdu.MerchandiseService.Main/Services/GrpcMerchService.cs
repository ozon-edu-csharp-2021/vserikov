using Grpc.Core;
using OzonEdu.MerchandiseService.Grpc;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Main.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Main.Services
{
    public class GrpcMerchService : MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        private readonly IMerchService _service;

        public GrpcMerchService(IMerchService service)
        {
            _service = service;
        }

        public override async Task<RequestCreatedGrpcModel> RequestMerch(RequestMerchGrpcModel request, ServerCallContext context)
        {
            var remap = new RequestMerchModel
            {
                RecieverId = request.RecieverId,
                MerchType = request.MerchType,
                Quantity = request.Quantity
            };

            await _service.CreateMerchRequest(remap, context.CancellationToken);
            return new RequestCreatedGrpcModel();
        }

        public override async Task<GetMerchInfoResponse> GetMerchInfo(GetMerchInfoRequest request, ServerCallContext context)
        {
            var items = await _service.GetInfoAboutMerchGiving(context.CancellationToken);

            return new GetMerchInfoResponse
            {
                Items = { items.Select(s=> new GetMerchInfoResponseUnit()
                {
                    SenderId = s.SenderId,
                    RecieverId = s.ReceiverId,
                    MerchType = s.MerchType,
                    Quantity = s.Quantity
                })}
            };
        }
    }
}
