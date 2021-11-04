using MediatR;

namespace MerchandiseService.Domain.Events
{
    public class MerchOrderReadyToIssueDomainEvent : INotification
    {
        public long EmployeeId { get; }

        public MerchOrderReadyToIssueDomainEvent(long employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}