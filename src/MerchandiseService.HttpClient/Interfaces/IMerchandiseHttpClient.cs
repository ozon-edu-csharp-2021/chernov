using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpModels;

namespace MerchandiseService.HttpClient.Interfaces
{
    public interface IMerchandiseHttpClient
    {
        Task<MerchOrderResponse> GetMerchOrderById(long id, CancellationToken token);
    }
}