using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpModels;
using MerchandiseService.Models;
using MerchandiseService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers
{
    [ApiController]
    [Route("v1/api/MerchOrders")]
    [Produces("application/json")]
    public class MerchOrderController : ControllerBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchOrderController(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }

        [HttpGet("{id:long}")]
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