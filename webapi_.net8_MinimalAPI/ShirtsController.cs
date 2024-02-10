using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [ActionFilter_IdValidation]
        public IActionResult UpdateShirtBy(int id, ShirtModel shirt)
        {
            if (id != shirt.Id) { return BadRequest(); }
            try { Repository.UpdateShirt(shirt); }
            catch { if (!Repository.shirtExists(id)) { return NotFound(); } throw; }//incase shirt is deleted earlier
            //return NoContent();
            return Ok(new { message = "updated successfully", shirt });

        

        }

        [HttpDelete("{id}")]
        public string DeleteShirtBy(int id)
        {
            return $"deleting shirt {id} from controller";
        }
        
    }
}
