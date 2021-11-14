using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.AggregationModels.MerchOrderAggregate;
using MerchandiseService.Domain.Models;
using MerchandiseService.Infrastructure.Commands.CreateMerchOrder;

namespace MerchandiseService.Infrastructure.Services
{
    public class MerchandiseService
    {
        private readonly IMerchOrderRepository _merchOrderRepository;

        private readonly IEmployeeRepository _employeeRepository;

        public MerchandiseService(IMerchOrderRepository merchOrderRepository,
            IEmployeeRepository employeeRepository)
        {
            _merchOrderRepository = merchOrderRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<int> CreateMerchOrder(CreateMerchOrderCommand request, CancellationToken cancellationToken)
        {
            if (!CheckEmployeeExist(request.EmployeeId))
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

            newMerchOrder.CheckAvailability();

            var createResult = await _merchOrderRepository.CreateAsync(newMerchOrder, cancellationToken);
            await _merchOrderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return newMerchOrder.Id;
        }
        
        private bool CheckActiveOrders(List<MerchOrder> orders)
        {
            if (orders.Where(it => it.Status != MerchOrderStatus.Done).Any())
            {
                return true;
            }
            return false;
        }

        private bool CheckLastYearMerchIssue(List<MerchOrder> orders){
            var currentDate = DateTime.Today;
            if (orders.Where(it =>
                currentDate.Subtract(it.DateOfIssue).Days <
                365).Any())
            {
                return true;
            }
            return false;
        }

        private bool CheckEmployeeExist(long id)
        {
            var employee = _employeeRepository.FindByIdAsync(id);
            return employee != null;
        }
    }
}