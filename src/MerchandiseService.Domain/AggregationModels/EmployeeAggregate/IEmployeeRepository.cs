using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> FindByIdAsync(long id, CancellationToken cancellationToken = default);
        
        Task<Employee> FindByEmailAsync(string email, CancellationToken cancellationToken = default);
        
        Task<List<Employee>> GetAllEmployees(CancellationToken cancellationToken = default);
    }
}