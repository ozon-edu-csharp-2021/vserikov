using OzonEdu.MerchandiseService.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public interface IMerchRequestRepository : IRepository<MerchRequest>
    {
        /// <summary>
        /// Получить запрос по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор запроса</param>
        /// <param name="cancellationToken">Токен для отмены операции<see cref="CancellationToken"/></param>
        /// <returns>Объект запроса</returns>
        Task<MerchRequest> FindByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запрос по номеру запроса
        /// </summary>
        /// <param name="stockItem">Номер запроса</param>
        /// <param name="cancellationToken">Токен для отмены операции<see cref="CancellationToken"/></param>
        /// <returns>Объект запроса</returns>
        Task<MerchRequest> FindByRequestNumberAsync(RequestNumber requestNumber, CancellationToken cancellationToken = default);
    }
}
