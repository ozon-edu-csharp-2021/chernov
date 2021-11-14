using MediatR;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.AggregationModels.MerchOrderAggregate;

namespace MerchandiseService.Domain.Events
{
    public class MerchOrderFormedDomainEvent : INotification
    {
        public MerchPack MerchPack { get; }

        public long MerchOrderId { get; }

        public MerchOrderFormedDomainEvent(long merchOrderId, MerchPack merchPack)
        {
            MerchOrderId = merchOrderId;
            MerchPack = merchPack;
        }
    }
}