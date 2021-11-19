using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.MerchOrderAggregate;
using MerchandiseService.Infrastructure.Queries.MerchOrderAggregate;

namespace MerchandiseService.Infrastructure.Handlers.Queries
{
    public class GetMerchOrderByIdQueryHandler : IRequestHandler<GetMerchOrderByIdQuery, MerchOrder>
    {
        private readonly IMerchOrderRepository _merchOrderRepository;

        public GetMerchOrderByIdQueryHandler(IMerchOrderRepository merchOrderRepository)
        {
            _merchOrderRepository = merchOrderRepository;
        }

        public async Task<MerchOrder> Handle(GetMerchOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var merchOrder = await _merchOrderRepository.FindByIdAsync(request.Id);
            return merchOrder;
        }
    }
}