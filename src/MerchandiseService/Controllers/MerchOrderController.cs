using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpModels;
using MerchandiseService.Models;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers
{
    [ApiController]
    [Route("v1/api/MerchOrders")]
    [Produces("application/json")]
    public class MerchOrderController : ControllerBase
    {
        private readonly Services.MerchandiseService _merchandiseService;

        public MerchOrderController(Services.MerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }

        [HttpGet("get/{id:long}")]
        public async Task<ActionResult<MerchOrder>> GetById(long id, CancellationToken token)
        {
            var merchOrder = await _merchandiseService.GetMerchOrderById(id, token);
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
            var createdMerchOrder = await _merchandiseService.AddMerchOrder(new MerchOrderCreationModel()
            {
                EmployeeId = merchOrderPostViewModel.EmployeeId,
                Status = merchOrderPostViewModel.Status
            }, token);
            return Ok(createdMerchOrder);
        }
    }
}