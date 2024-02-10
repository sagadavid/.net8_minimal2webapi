using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace webapi_.net8_MinimalAPI.ActionFilters
{
    public class ActionFilter_ShirtValidation : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);


            var shirtInAction = context.ActionArguments["shirt"] as ShirtModel;

            if (shirtInAction == null)
            {

                context.ModelState.AddModelError("shirt", "actionfilter on shirtValidation: shirt is null here");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);

            }

            else
            {

                var alreadyExist = Repository.GetShirtByProperties
                        (shirtInAction.Brand, shirtInAction.Color, shirtInAction.Gender, shirtInAction.Size);
                if (alreadyExist != null)
                {
                    context.ModelState.AddModelError("shirt", "actionfilter on shirtValidation: shirt already exist");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);

                }

            }




        }
    }
}
