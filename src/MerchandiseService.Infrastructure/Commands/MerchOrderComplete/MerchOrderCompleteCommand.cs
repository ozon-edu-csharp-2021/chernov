using MediatR;

namespace MerchandiseService.Infrastructure.Commands.MerchOrderComplete
{
    public class MerchOrderCompleteCommand : IRequest
    {
        public long MerchOderId { get; set; }
    }
}