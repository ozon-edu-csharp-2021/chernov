using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.HttpModels;
using MerchandiseService.Infrastructure.Commands.CreateEmployee;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers
{
    [ApiController]
    [Route("v1/api/Employees")]
    [Produces("application/json")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<ActionResult<Employee>> Add(EmployeePostViewModel merchOrderPostViewModel,
            CancellationToken token)
        {
            var createEmployeeCommand = new CreateEmployeeCommand()
            {
                FirstName = merchOrderPostViewModel.FirstName,
                LastName = merchOrderPostViewModel.LastName,
                MiddleName = merchOrderPostViewModel.MiddleName,
                Email = merchOrderPostViewModel.Email,
                ClothingSize = merchOrderPostViewModel.ClothingSize
            };
            var result = await _mediator.Send(createEmployeeCommand, token);
            return Ok(result);
        }
    }
}