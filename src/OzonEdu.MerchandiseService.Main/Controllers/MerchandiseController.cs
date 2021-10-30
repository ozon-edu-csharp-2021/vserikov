using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.HttpModels;
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

        public MerchandiseController(IMerchService service)
        {
            _service = service;
        }

        /// <summary>
        /// Запросить мерч
        /// </summary>
        /// <param name="request"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RequestMerch(RequestMerchModel request, CancellationToken token)
        {
            await _service.CreateMerchRequest(request, token);
            return Ok();
        }

        /// <summary>
        /// Получить информацию о выдаче мерча
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<SingleMerchModel>>> GetMerchInfo(CancellationToken token)
        {
            return Ok(await _service.GetInfoAboutMerchGiving(token));
        }
    }
}
