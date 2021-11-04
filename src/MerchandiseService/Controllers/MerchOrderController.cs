using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.HttpModels;
using MerchandiseService.Infrastructure.Commands.CreateMerchOrder;
using MerchandiseService.Infrastructure.Queries.MerchOrderAggregate;
using MerchandiseService.Models;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers
{
    [ApiController]
    [Route("v1/api/MerchOrders")]
    [Produces("application/json")]
    public class MerchOrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MerchOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get/{id:long}")]
        public async Task<ActionResult<MerchOrder>> GetById(long id, CancellationToken token)
        {
            var merchOrder = await _mediator.Send(new GetMerchOrderByIdQuery {Id = id});
            if (merchOrder is null)
            {
                return NotFound();
            }

            return Ok(merchOrder);
        }

        [HttpPost]
        public async Task<ActionResult<MerchOrder>> Add(MerchOrderPostViewModel merchOrderPostViewModel,
            CancellationToken token)
        {
            var createMerchOrderCommand = new CreateMerchOrderCommand
            {
                EmployeeId = merchOrderPostViewModel.EmployeeId,
                MerchPack = merchOrderPostViewModel.MerchPack,
                ClothingSize = merchOrderPostViewModel.ClothingSize
            };

            var result = await _mediator.Send(createMerchOrderCommand, token);

            return Ok(result);
        }
    }
}