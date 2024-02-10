using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace webapi_.net8_MinimalAPI
{
    public class ActionFilter_IdOnUpdateValidation : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;
            var shirtOnUpdate = context.ActionArguments["shirt"] as ShirtModel;

            if (id.HasValue&& shirtOnUpdate != null && id != shirtOnUpdate.Id) 
            {
                context.ModelState.AddModelError("id", "shirt id doesnt match");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            
            }
        }
    }
}
