using MediatR;

namespace MerchandiseService.Infrastructure.Commands.CreateMerchOrder
{
    public class CreateMerchOrderCommand : IRequest<int>
    {
        public long EmployeeId { get; set; }

        public int MerchPack { get; set; }
    }
}