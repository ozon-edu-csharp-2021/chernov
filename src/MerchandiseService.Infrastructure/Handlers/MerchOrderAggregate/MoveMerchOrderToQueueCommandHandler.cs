using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.MerchOrderAggregate;
using MerchandiseService.Infrastructure.Commands.MoveMerchOrderToQueue;

namespace MerchandiseService.Infrastructure.Handlers.MerchOrderAggregate
{
    public class MoveMerchOrderToQueueCommandHandler : IRequestHandler<MoveMerchOrderToQueueCommand>
    {
        private readonly IMerchOrderRepository _merchOrderRepository;

        public MoveMerchOrderToQueueCommandHandler(IMerchOrderRepository merchOrderRepository)
        {
            _merchOrderRepository = merchOrderRepository;
        }

        public async Task<Unit> Handle(MoveMerchOrderToQueueCommand request, CancellationToken cancellationToken)
        {
            var merchOrder = await _merchOrderRepository.FindByIdAsync(request.MerchOrderId, cancellationToken);
            if (merchOrder.Status != MerchOrderStatus.InProgress)
            {
                throw new Exception("Incorrect request status");
            }

            merchOrder.MoveToQueue();
            await _merchOrderRepository.UpdateAsync(merchOrder);
            await _merchOrderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}