using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.MerchOrderAggregate
{
    public interface IMerchOrderRepository : IRepository<MerchOrder>
    {
        Task<MerchOrder> FindByIdAsync(long id, CancellationToken cancellationToken = default);
        
        Task<List<MerchOrder>> FindByEmployeeIdAsync(long id, CancellationToken cancellationToken = default);
    }
}