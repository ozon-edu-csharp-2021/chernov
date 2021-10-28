using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Models;

namespace MerchandiseService.Services.Interfaces
{
    public interface IMerchandiseService
    {
        Task<MerchOrder> GetMerchOrderById(long id, CancellationToken token);

        Task<MerchOrder> AddMerchOrder(MerchOrderCreationModel merchOrderCreationModel, CancellationToken token);
    }
}