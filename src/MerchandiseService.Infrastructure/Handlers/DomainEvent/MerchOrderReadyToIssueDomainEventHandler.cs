using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.Events;

namespace MerchandiseService.Infrastructure.Handlers.DomainEvent
{
    //отправка email сотруднику, что его мерч готов
    public class MerchOrderReadyToIssueDomainEventHandler : INotificationHandler<MerchOrderReadyToIssueDomainEvent>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public MerchOrderReadyToIssueDomainEventHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task Handle(MerchOrderReadyToIssueDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}