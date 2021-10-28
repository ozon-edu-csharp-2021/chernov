using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MerchandiseService.Grpc;
using MerchandiseService.Models;
using MerchandiseService.Services.Interfaces;

namespace MerchandiseService.GrpcServices
{
    public class MerchandiseGrpcService : MerchandiseGrpc.MerchandiseGrpcBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchandiseGrpcService(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }

        public override async Task<GetMerchOrderByIdResponseUnit> GetMerchOrderById(GetMMerchOrderByIdRequest request,
            ServerCallContext context)
        {
            var merchOrder = await _merchandiseService.GetMerchOrderById(request.Id, context.CancellationToken);
            return new GetMerchOrderByIdResponseUnit
            {
                Id = merchOrder.Id,
                EmployeeId = merchOrder.EmployeeId,
                Status = merchOrder.Status
            };
        }

        public override async Task<Empty> AddMerchOrder(AddMerchOrderRequest request, ServerCallContext context)
        {
            await _merchandiseService.AddMerchOrder(new MerchOrderCreationModel
            {
                EmployeeId = request.EmployeeId,
                Status = request.Status
            }, context.CancellationToken);
            return new Empty();
        }
    }
}