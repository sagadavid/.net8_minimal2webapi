using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace webapi_.net8_MinimalAPI
{
    public class ActionFilter_IdValidation : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var idInAction=context.ActionArguments["id"] as int?;
            if (idInAction.HasValue)
            {
                if (idInAction.Value <= 0)
                {
                    context.ModelState.AddModelError("id", "shirt id value is invalid");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }

                else if (!Repository.shirtExists(idInAction.Value))
                {
                    context.ModelState.AddModelError("id", "shirt doesnt exist");
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
