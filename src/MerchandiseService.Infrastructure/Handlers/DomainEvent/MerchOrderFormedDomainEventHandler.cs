using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.Events;

namespace MerchandiseService.Infrastructure.Handlers.DomainEvent
{
    public class MerchOrderFormedDomainEventHandler : INotificationHandler<MerchOrderFormedDomainEvent>
    {
        public Task Handle(MerchOrderFormedDomainEvent notification, CancellationToken cancellationToken)
        {
            //TODO проверка на наличие в Stock Api
            throw new System.NotImplementedException();
        }
    }
}