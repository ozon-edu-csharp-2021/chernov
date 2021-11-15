using System;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.Events;
using MerchandiseService.Domain.Exceptions.MerchOrderAggregate;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchOrderAggregate
{
    public class MerchOrder : Entity
    {
        public MerchOrderStatus Status { get; private set; }

        public Employee Employee { get; }
        
        public long EmployeeId { get; }

        public MerchPack MerchPack { get; }

        public DateTime DateOfIssue { get; private set; }

        public MerchOrder(Employee employee, MerchPack merchPack)
        {
            Employee = employee;
            EmployeeId = employee.Id;
            MerchPack = merchPack;
            Status = MerchOrderStatus.Created;
        }

        public void MoveToQueue()
        {
            if (Status != MerchOrderStatus.CheckingItemAvailability)
            {
                throw new IncorrectOrderStatusException("Status should be CheckingItemAvailability");
            }

            Status = MerchOrderStatus.InQueueForIssue;
        }

        public void CheckAvailability()
        {
            if (Status != MerchOrderStatus.Created && Status != MerchOrderStatus.InQueueForIssue)
            {
                throw new IncorrectOrderStatusException("Status should be Created or InQueueForIssue");
            }

            Status = MerchOrderStatus.CheckingItemAvailability;
            AddMerchOrderFormedDomainEvent(Id);
        }

        public void Complete()
        {
            if (Status != MerchOrderStatus.CheckingItemAvailability)
            {
                throw new IncorrectOrderStatusException("Status should be CheckingItemAvailability");
            }

            Status = MerchOrderStatus.Done;
            DateOfIssue = DateTime.Today;
            AddMerchOrderReadyToIssueDomainEvent(Employee, MerchPack);
        }

        private void AddMerchOrderReadyToIssueDomainEvent(Employee employee, MerchPack merchPack)
        {
            var merchOrderReadyToIssueDomainEvent = new MerchOrderReadyToIssueDomainEvent(employee, merchPack);
            this.AddDomainEvent(merchOrderReadyToIssueDomainEvent);
        }

        private void AddMerchOrderFormedDomainEvent(long merchOrderId)
        {
            var merchOrderFormedDomainEvent = new MerchOrderFormedDomainEvent(merchOrderId);
            this.AddDomainEvent(merchOrderFormedDomainEvent);
        }
    }
}