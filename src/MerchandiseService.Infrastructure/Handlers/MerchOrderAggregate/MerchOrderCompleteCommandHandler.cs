using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.MerchOrderAggregate;
using MerchandiseService.Infrastructure.Commands.MerchOrderComplete;

namespace MerchandiseService.Infrastructure.Handlers.MerchOrderAggregate
{
    public class MerchOrderCompleteCommandHandler : IRequestHandler<MerchOrderCompleteCommand>
    {
        private readonly IMerchOrderRepository _merchOrderRepository;

        public MerchOrderCompleteCommandHandler(IMerchOrderRepository merchOrderRepository)
        {
            _merchOrderRepository = merchOrderRepository;
        }

        public async Task<Unit> Handle(MerchOrderCompleteCommand request, CancellationToken cancellationToken)
        {
            var merchOrder = await _merchOrderRepository.FindByIdAsync(request.MerchOderId, cancellationToken);
            if (merchOrder.Status != MerchOrderStatus.CheckingItemAvailability)
            {
                throw new Exception("Incorrect request status");
            }

            merchOrder.Complete();
            await _merchOrderRepository.UpdateAsync(merchOrder);
            await _merchOrderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}