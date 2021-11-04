using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.Events;

namespace MerchandiseService.Infrastructure.Handlers.DomainEvent
{
    //проверка на наличие в Stock Api
    public class MerchOrderFormedDomainEventHandler : INotificationHandler<MerchOrderFormedDomainEvent>
    {
        public Task Handle(MerchOrderFormedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}