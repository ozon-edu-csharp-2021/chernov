using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.AggregationModels.MerchOrderAggregate;
using MerchandiseService.Domain.Contracts;
using MerchandiseService.Domain.Models;
using MerchandiseService.Infrastructure.Commands.CreateMerchOrder;

namespace MerchandiseService.Infrastructure.Services
{
    public class MerchandiseService
    {
        private readonly IMerchOrderRepository _merchOrderRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MerchandiseService(IMerchOrderRepository merchOrderRepository,
            IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _merchOrderRepository = merchOrderRepository;
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateMerchOrder(CreateMerchOrderCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.StartTransaction(cancellationToken);

            var employee = await _employeeRepository.FindByIdAsync(request.EmployeeId);
            if (employee == null)
            {
                throw new Exception("Employee does not exist");
            }

            var orders = await _merchOrderRepository.FindByEmployeeIdAsync(request.EmployeeId, cancellationToken);
            orders = orders.Where(it => it.MerchPack.Id == request.MerchPack).ToList();

            if (CheckActiveOrders(orders))
            {
                throw new Exception("Request for such a merch has already been created for this employee");
            }

            if (CheckLastYearMerchIssue(orders))
            {
                throw new Exception("In this year such merch has already been issued");
            }

            var newMerchOrder =
                new MerchOrder(request.EmployeeId,
                    Enumeration.GetAll<MerchPack>().FirstOrDefault(it => it.Id.Equals(request.MerchPack)));
            newMerchOrder.Employee = employee;
            
            var createResult = await _merchOrderRepository.CreateAsync(newMerchOrder, cancellationToken);
            
            newMerchOrder.CheckAvailability();
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return createResult.Id;
        }

        private bool CheckActiveOrders(List<MerchOrder> orders)
        {
            if (orders.Where(it => it.Status != MerchOrderStatus.Done).Any())
            {
                return true;
            }

            return false;
        }

        private bool CheckLastYearMerchIssue(List<MerchOrder> orders)
        {
            var currentDate = DateTime.Today;
            if (orders.Where(it =>
                currentDate.Subtract(it.DateOfIssue).Days <
                365).Any())
            {
                return true;
            }

            return false;
        }
    }
}