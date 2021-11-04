using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.AggregationModels.MerchOrderAggregate;

namespace MerchandiseService.Infrastructure.DomainServices
{
    public class MerchandiseDomainService
    {
        private readonly IMerchOrderRepository _merchOrderRepository;

        private readonly IEmployeeRepository _employeeRepository;

        public MerchandiseDomainService(IMerchOrderRepository merchOrderRepository,
            IEmployeeRepository employeeRepository)
        {
            _merchOrderRepository = merchOrderRepository;
            _employeeRepository = employeeRepository;
        }
    }
}