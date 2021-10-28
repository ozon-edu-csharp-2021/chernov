using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MerchandiseService.Infrastructure.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            var resultObject = new
            {
                ExtionType = context.Exception.GetType().FullName,
                Message = context.Exception.Message,
                StackTrace = context.Exception.StackTrace
            };

            var jsonresult = new JsonResult(resultObject)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            context.Result = jsonresult;
        }
    }
}