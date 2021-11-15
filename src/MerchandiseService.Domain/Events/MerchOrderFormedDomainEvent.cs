using MediatR;

namespace MerchandiseService.Domain.Events
{
    public class MerchOrderFormedDomainEvent : INotification
    {
        public long MerchOrderId { get; }

        public MerchOrderFormedDomainEvent(long merchOrderId)
        {
            MerchOrderId = merchOrderId;
        }
    }
}