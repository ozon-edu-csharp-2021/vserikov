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

        public override async Task<RequestMerchOutputModel> RequestMerch(RequestMerchInputModel request, ServerCallContext context)
        {
            var remap = new RequestMerchModel
            {
                RecieverId = request.RecieverId,
                MerchType = request.MerchType,
                Quantity = request.Quantity
            };

            await _service.CreateMerchRequest(remap, context.CancellationToken);
            return new RequestMerchOutputModel();
        }

        public override async Task<MerchInfoOutputModel> GetMerchInfo(MerchInfoInputModel request, ServerCallContext context)
        {
            var items = await _service.GetInfoAboutMerchGiving(context.CancellationToken);

            return new MerchInfoOutputModel
            {
                Items = { items.Select(s=> new MerchInfoUnitModel()
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
