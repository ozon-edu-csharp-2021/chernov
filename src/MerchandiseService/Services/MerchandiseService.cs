using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Models;

namespace MerchandiseService.Services
{
    public class MerchandiseService
    {
        private readonly List<MerchOrder> MerchOrders =
            new List<MerchOrder>
            {
                new MerchOrder(1, 1, "Выдан"),
                new MerchOrder(2, 4, "В процессе выдачи"),
                new MerchOrder(3, 5, "Выдан")
            };

        public Task<MerchOrder> GetMerchOrderById(long id, CancellationToken token)
        {
            var merchOrder = MerchOrders.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(merchOrder);
        }

        public Task<MerchOrder> AddMerchOrder(MerchOrderCreationModel merchOrderCreationModel, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }
    }
}