using MediatR;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Infrastructure.Commands;
using OzonEdu.MerchandiseService.Infrastructure.Queries;
using OzonEdu.MerchandiseService.Main.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Main.Controllers
{
    [ApiController]
    [Route("v1/api/merchandise/[action]")]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMerchService _service;
        private readonly IMediator _mediator;

        public MerchandiseController(IMerchService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        /// <summary>
        /// Запросить мерч
        /// </summary>
        /// <param name="request"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RequestMerch(RequestMerchModel request, CancellationToken token)
            => Ok(await _mediator.Send(new CreateMerchRequestCommand(request.SenderId, request.SenderId, request.PackId, request.Quantity), token));

        /// <summary>
        /// Получить информацию о выдаче мерча
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<MerchItem>>> GetMerchGivingInfo(CancellationToken token)
            => Ok(await _mediator.Send(new GetMerchGivingInfoQuery(), token));
    }
}
