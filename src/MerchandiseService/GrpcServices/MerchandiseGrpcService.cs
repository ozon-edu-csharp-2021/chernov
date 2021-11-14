using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MerchandiseService.Grpc;
using MerchandiseService.Models;

namespace MerchandiseService.GrpcServices
{
    public class MerchandiseGrpcService : MerchandiseGrpc.MerchandiseGrpcBase
    {
        private readonly global::MerchandiseService.Services.MerchandiseService _merchandiseService;

        public MerchandiseGrpcService(global::MerchandiseService.Services.MerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }

        public override async Task<GetMerchOrderByIdResponse> GetMerchOrderById(GetMerchOrderByIdRequest request,
            ServerCallContext context)
        {
            var merchOrder = await _merchandiseService.GetMerchOrderById(request.Id, context.CancellationToken);
            return new GetMerchOrderByIdResponse
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