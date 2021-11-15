using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.MerchOrderAggregate;
using MerchandiseService.Domain.Events;

namespace MerchandiseService.Infrastructure.Handlers.DomainEvent
{
    public class MerchOrderFormedDomainEventHandler : INotificationHandler<MerchOrderFormedDomainEvent>
    {
        private readonly IMerchOrderRepository _merchOrderRepository;

        public MerchOrderFormedDomainEventHandler(IMerchOrderRepository merchOrderRepository)
        {
            _merchOrderRepository = merchOrderRepository;
        }
        
        public async Task Handle(MerchOrderFormedDomainEvent notification, CancellationToken cancellationToken)
        {
            var merchOrder = await _merchOrderRepository.FindByIdAsync(notification.MerchOrderId, cancellationToken);
            
            if (CheckAvailability(merchOrder))
            {
                IssueMerch(merchOrder);
                merchOrder.Complete();
            }
            else
            {
                merchOrder.MoveToQueue();
            }
            
            await _merchOrderRepository.UpdateAsync(merchOrder);
            await _merchOrderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

        private void IssueMerch(MerchOrder merchOrder)
        {
            //TODO запрос на выдачу в Stock Api
        }

        private bool CheckAvailability(MerchOrder merchOrder)
        {
            //TODO проверка на наличие в Stock Api
            throw new System.NotImplementedException();
        }
    }
}