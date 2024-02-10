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
        public string UpdateShirtBy(int id)
        {
            return $"updating shirt id {id} from controller";

        }

        [HttpDelete("{id}")]
        public string DeleteShirtBy(int id)
        {
            return $"deleting shirt {id} from controller";
        }
        
    }
}
