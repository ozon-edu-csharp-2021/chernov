using System;
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

        public ClothingSize ClothingSize { get; private set; }

        public Date DateOfIssue { get; private set; }

        public MerchOrder(long employeeId, MerchPack merchPack)
        {
            EmployeeId = employeeId;
            MerchPack = merchPack;
            Status = MerchOrderStatus.Created;
        }

        public void SetClothingSize(ClothingSize clothingSize)
        {
            ClothingSize = clothingSize;
        }

        public void MoveToQueue()
        {
            if (Status != MerchOrderStatus.InProgress)
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

            if (MerchPack.IsNeedSize && ClothingSize == null)
            {
                throw new ClothingSizeException("Size must be specified");
            }

            Status = MerchOrderStatus.InProgress;
            AddMerchOrderFormedDomainEvent(Id, MerchPack, ClothingSize);
        }

        public void Complete()
        {
            if (Status != MerchOrderStatus.InProgress)
            {
                throw new IncorrectOrderStatusException("Status should be InProgress");
            }

            Status = MerchOrderStatus.Done;
            var currentDate = DateTime.Today;
            DateOfIssue = new Date(currentDate.Day, currentDate.Month, currentDate.Year);
            AddMerchOrderReadyToIssueDomainEvent(EmployeeId);
        }

        private void AddMerchOrderReadyToIssueDomainEvent(long employeeId)
        {
            var merchOrderReadyToIssueDomainEvent = new MerchOrderReadyToIssueDomainEvent(employeeId);
            this.AddDomainEvent(merchOrderReadyToIssueDomainEvent);
        }

        private void AddMerchOrderFormedDomainEvent(long merchOrderId, MerchPack merchPack, ClothingSize clothingSize)
        {
            var merchOrderFormedDomainEvent = new MerchOrderFormedDomainEvent(merchOrderId, merchPack, clothingSize);
            this.AddDomainEvent(merchOrderFormedDomainEvent);
        }
    }
}