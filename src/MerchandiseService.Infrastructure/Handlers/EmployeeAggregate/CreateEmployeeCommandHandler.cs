using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.Contracts;
using MerchandiseService.Domain.Models;
using MerchandiseService.Infrastructure.Commands.CreateEmployee;

namespace MerchandiseService.Infrastructure.Handlers.EmployeeAggregate
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.StartTransaction(cancellationToken);
            var newEmployee = new Employee(
                new EmployeeName(request.FirstName, request.LastName, request.MiddleName),
                Email.Create(request.Email),
                Enumeration.GetAll<ClothingSize>().FirstOrDefault(it => it.Id.Equals(request.ClothingSize)));
            
            var createResult = await _employeeRepository.CreateAsync(newEmployee, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return createResult.Id;
        }
    }
}