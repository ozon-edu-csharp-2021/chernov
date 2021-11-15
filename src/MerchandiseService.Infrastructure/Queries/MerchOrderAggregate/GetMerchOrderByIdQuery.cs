using MediatR;
using MerchandiseService.Domain.AggregationModels.MerchOrderAggregate;

namespace MerchandiseService.Infrastructure.Queries.MerchOrderAggregate
{
    public class GetMerchOrderByIdQuery : IRequest<MerchOrder>
    {
        public long Id { get; set; }
    }
}