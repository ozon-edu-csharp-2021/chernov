using MediatR;

namespace MerchandiseService.Infrastructure.Commands.MoveMerchOrderToQueue
{
    public class MoveMerchOrderToQueueCommand : IRequest
    {
        public long MerchOrderId { get; set; }

        public MoveMerchOrderToQueueCommand(long merchOrderId)
        {
            MerchOrderId = merchOrderId;
        }
    }
}