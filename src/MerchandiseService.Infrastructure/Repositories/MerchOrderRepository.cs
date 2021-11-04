using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.MerchOrderAggregate;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Infrastructure.Repositories
{
    public class MerchOrderRepository : IMerchOrderRepository
    {
        private readonly List<MerchOrder> MerchOrders =
            new List<MerchOrder>
            {
                new MerchOrder(1, MerchPack.StarterPack),
                new MerchOrder(2, MerchPack.VeteranPack),
                new MerchOrder(2, MerchPack.ConferenceSpeakerPack),
                new MerchOrder(3, MerchPack.WelcomePack)
            };


        public IUnitOfWork UnitOfWork { get; }

        Task<MerchOrder> IRepository<MerchOrder>.CreateAsync(MerchOrder itemToCreate,
            CancellationToken cancellationToken)
        {
            MerchOrders.Add(itemToCreate);
            return Task.FromResult<MerchOrder>(itemToCreate);
        }

        public Task<MerchOrder> UpdateAsync(MerchOrder itemToUpdate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<MerchOrder> FindByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var order = MerchOrders.FirstOrDefault(it => it.Id == id);
            return Task.FromResult(order);
        }

        public Task<List<MerchOrder>> FindByEmployeeIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var order = MerchOrders.Where(it => it.EmployeeId == id).ToList();
            return Task.FromResult(order);
        }
    }
}