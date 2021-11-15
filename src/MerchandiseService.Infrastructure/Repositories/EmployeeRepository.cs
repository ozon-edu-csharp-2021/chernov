using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public static readonly List<Employee> Employees =
            new List<Employee>
            {
                new Employee(new EmployeeName("firstName1", "lastName1", "middleName1"), Email.Create("employee1@gmail.com"),ClothingSize.M ),
                new Employee(new EmployeeName("firstName2", "lastName2", "middleName2"), Email.Create("employee2@gmail.com"),ClothingSize.S ),
                new Employee(new EmployeeName("firstName3", "lastName3", "middleName3"), Email.Create("employee3@gmail.com"),ClothingSize.XL ),
                new Employee(new EmployeeName("firstName4", "lastName4", "middleName4"), Email.Create("employee4@gmail.com"),ClothingSize.L )
            };   
        
        
        public IUnitOfWork UnitOfWork { get; }
        public Task<Employee> CreateAsync(Employee itemToCreate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> UpdateAsync(Employee itemToUpdate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> FindByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var employee = Employees.FirstOrDefault(it => it.Id == id);
            return Task.FromResult(employee);
        }

        public Task<Employee> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Employee>> GetAllEmployees(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}