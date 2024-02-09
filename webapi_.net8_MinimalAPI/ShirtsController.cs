using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi_.net8_MinimalAPI
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ShirtsController : ControllerBase
    {

        [HttpGet]
        public string GetAllShirts() {
            return "getting from controller";
        }

        [HttpGet("{id}")]
        [ActionFilter_IdValidation]
        public IActionResult GetShirtBy(int id)
        {
           
            return Ok(Repository.GetShirtModelById(id));
            
        }

        [HttpPost]
        public string CreateShirt([FromForm]ShirtModel shirt)
        {
            return $"creating shirts from controller";
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
