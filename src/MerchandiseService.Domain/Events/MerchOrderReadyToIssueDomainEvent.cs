using MediatR;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.AggregationModels.MerchOrderAggregate;

namespace MerchandiseService.Domain.Events
{
    public class MerchOrderReadyToIssueDomainEvent : INotification
    {
        public Employee Employee { get; }
        
        public MerchPack MerchPack { get; }

        public MerchOrderReadyToIssueDomainEvent(Employee employee, MerchPack merchPack)
        {
            Employee = employee;
            MerchPack = merchPack;
        }
    }
}