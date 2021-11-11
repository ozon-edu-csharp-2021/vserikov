using OzonEdu.MerchandiseService.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public interface IMerchItemRepository : IRepository<MerchItem>
    {
        /// <summary>
        /// Найти набор мерча по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор набора мерча</param>
        /// <param name="cancellationToken">Токен для отмены операции<see cref="CancellationToken"/></param>
        /// <returns>Набор мерча</returns>
        Task<MerchItem> FindByIdAsync(long id, CancellationToken token = default);

        /// <summary>
        /// Найти отправителя или получателя по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Employee> FindEmployeeByIdAsync(int id, CancellationToken token = default);

        /// <summary>
        /// Получить информацию по всем отправкам мерча
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<List<MerchItem>> GetAllAsync(CancellationToken token = default);
    }
}
