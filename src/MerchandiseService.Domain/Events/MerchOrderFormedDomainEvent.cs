using MediatR;
using MerchandiseService.Domain.AggregationModels.MerchOrderAggregate;

namespace MerchandiseService.Domain.Events
{
    public class MerchOrderFormedDomainEvent : INotification
    {
        public MerchPack MerchPack { get; }
        public ClothingSize ClothingSize { get; }

        public long MerchOrderId { get; }

        public MerchOrderFormedDomainEvent(long merchOrderId, MerchPack merchPack, ClothingSize clothingSize)
        {
            MerchOrderId = merchOrderId;
            MerchPack = merchPack;
            ClothingSize = clothingSize;
        }
    }
}