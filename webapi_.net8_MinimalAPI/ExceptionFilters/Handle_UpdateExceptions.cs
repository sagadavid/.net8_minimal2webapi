using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace webapi_.net8_MinimalAPI.ExceptionFilters
{
    public class Handle_UpdateExceptions : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strShirtIdOnException = context.RouteData.Values["id"] as string;
            if (int.TryParse(strShirtIdOnException, out int intShirtId))
            {
                if (!Repository.shirtExists(intShirtId))
                {
                    context.ModelState.AddModelError("id", "handled exception : shirt doesnt exist anymore");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }







        }
    }
}
