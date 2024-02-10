using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_.net8_MinimalAPI.ActionFilters;
using webapi_.net8_MinimalAPI.ExceptionFilters;

namespace webapi_.net8_MinimalAPI
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ShirtsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllShirts() {
            return Ok(Repository.GetShirtModel());
        }

        [HttpGet("{id}")]
        [ActionFilter_IdValidation]
        public IActionResult GetShirtBy(int id)
        {
           
            return Ok(Repository.GetShirtModelById(id));
             
        }

        [HttpPost]
        [ActionFilter_ShirtValidation]
        public IActionResult CreateShirt([FromBody]ShirtModel shirt)//reminder! post as json
        {
            Repository.AddShirts(shirt);
            return CreatedAtAction(nameof(GetShirtBy), new { id = shirt.Id }, shirt);

            
        }

        [HttpPut("{id}")]
        //[ActionFilter_IdValidation]//commented to let handle_updateexception works
        [ActionFilter_IdOnUpdateValidation]
        [Handle_UpdateExceptions]
        public IActionResult UpdateShirtBy(int id, ShirtModel shirt)
        {
            Repository.UpdateShirt(shirt);
            return Ok(new { message = "updated successfully", shirt });

        

        }

        [HttpDelete("{id}")]
        [ActionFilter_IdValidation]
        public IActionResult DeleteShirtBy(int id)
        {
            var shirtToDeleteCalled = Repository.GetShirtModelById(id);//called just to return in Ok
            Repository.DeleteShirt(id);
            return Ok(new { message = "deletion success", shirtToDeleteCalled });
        }
        
    }
}
