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

        public long EmployeeId { get; }

        public MerchPack MerchPack { get; }

        public DateTime DateOfIssue { get; private set; }

        public MerchOrder(long employeeId, MerchPack merchPack)
        {
            EmployeeId = employeeId;
            MerchPack = merchPack;
            Status = MerchOrderStatus.Created;
        }

        public void MoveToQueue()
        {
            if (Status != MerchOrderStatus.CheckingItemAvailability)
            {
                throw new IncorrectOrderStatusException("Status should be InProgress");
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
            AddMerchOrderFormedDomainEvent(Id, MerchPack);
        }

        public void Complete()
        {
            if (Status != MerchOrderStatus.CheckingItemAvailability)
            {
                throw new IncorrectOrderStatusException("Status should be InProgress");
            }

            Status = MerchOrderStatus.Done;
            DateOfIssue = DateTime.Today;
            AddMerchOrderReadyToIssueDomainEvent(EmployeeId);
        }

        private void AddMerchOrderReadyToIssueDomainEvent(long employeeId)
        {
            var merchOrderReadyToIssueDomainEvent = new MerchOrderReadyToIssueDomainEvent(employeeId);
            this.AddDomainEvent(merchOrderReadyToIssueDomainEvent);
        }

        private void AddMerchOrderFormedDomainEvent(long merchOrderId, MerchPack merchPack)
        {
            var merchOrderFormedDomainEvent = new MerchOrderFormedDomainEvent(merchOrderId, merchPack);
            this.AddDomainEvent(merchOrderFormedDomainEvent);
        }
    }
}