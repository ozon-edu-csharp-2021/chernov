using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.MerchOrderAggregate;
using MerchandiseService.Domain.Models;
using MerchandiseService.Infrastructure.Commands.CreateMerchOrder;

namespace MerchandiseService.Infrastructure.Handlers.MerchOrderAggregate
{
    public class CreateMerchOrderCommandHandler : IRequestHandler<CreateMerchOrderCommand, int>
    {
        private readonly IMerchOrderRepository _merchOrderRepository;

        public CreateMerchOrderCommandHandler(IMerchOrderRepository merchOrderRepository)
        {
            _merchOrderRepository = merchOrderRepository;
        }

        public async Task<int> Handle(CreateMerchOrderCommand request, CancellationToken cancellationToken)
        {
            var orders = await _merchOrderRepository.FindByEmployeeIdAsync(request.EmployeeId, cancellationToken);
            orders = orders.Where(it => it.MerchPack.Id == request.MerchPack).ToList();

            //проверка - есть ли такие-же активные запросы для этого сотрудника
            if (orders.Where(it => it.Status != MerchOrderStatus.Done).Any())
            {
                throw new Exception("Request for such a merch has already been created for this employee");
            }

            //проверка - выдавался ли такой мерч за последний год
            var currentDate = DateTime.Today;
            if (orders.Where(it =>
                currentDate.Subtract(new DateTime(it.DateOfIssue.Year, it.DateOfIssue.Month, it.DateOfIssue.Day)).Days <
                365).Any())
            {
                throw new Exception("In this year such merch has already been issued");
            }

            var newMerchOrder =
                new MerchOrder(request.EmployeeId,
                    Enumeration.GetAll<MerchPack>().FirstOrDefault(it => it.Id.Equals(request.MerchPack)));
            //new Email(request.EmployeeEmail));

            if (request.ClothingSize != null && newMerchOrder.MerchPack.IsNeedSize)
            {
                newMerchOrder.SetClothingSize(Enumeration.GetAll<ClothingSize>()
                    .FirstOrDefault(it => it.Id.Equals(request.ClothingSize)));
            }
            else if (request.ClothingSize == null && newMerchOrder.MerchPack.IsNeedSize)
            {
                throw new Exception("Size must be specified");
            }

            newMerchOrder.CheckAvailability();

            var createResult = await _merchOrderRepository.CreateAsync(newMerchOrder, cancellationToken);
            await _merchOrderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return newMerchOrder.Id;
        }
    }
}