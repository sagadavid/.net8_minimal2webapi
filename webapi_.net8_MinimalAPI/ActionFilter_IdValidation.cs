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
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }

                else if (!Repository.shirtExists(idInAction.Value))
                {
                    context.ModelState.AddModelError("id", "shirt doesnt exist");
                    context.Result = new NotFoundObjectResult(context.ModelState);

                }
            }



        }
    }
}
