using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.Events;

namespace MerchandiseService.Infrastructure.Handlers.DomainEvent
{
    public class MerchOrderReadyToIssueDomainEventHandler : INotificationHandler<MerchOrderReadyToIssueDomainEvent>
    {
        public async Task Handle(MerchOrderReadyToIssueDomainEvent notification, CancellationToken cancellationToken)
        {
            string message = $"Мерч {notification.MerchPack.Name} готов к выдаче";
            SendEmail(notification.Employee.Email, message);
        }

        private void SendEmail(Email email, string message)
        {
            //TODO отправка email сотруднику, что его мерч готов
            throw new NotImplementedException();
        }
    }
}