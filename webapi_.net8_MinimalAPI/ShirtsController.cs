using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi_.net8_MinimalAPI
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ShirtsController : ControllerBase
    {
        [HttpGet]
        //[Route("/shirts")]
        public string GetAllShirts() {
            return "getting from controller";
        }

        [HttpGet("{id}/{color}")]
        //[Route("/shirts/{id}")]
        public string GetShirtById(int id, [FromRoute] string color)
        {
            return $"getting shirt id {id} and color {color} from controller";
        }

        [HttpPost]
        //[Route("/shirts")]
        public string CreateShirt()
        {
            return $"creating shirts from controller";
        }

        [HttpPut("{id}")]
        //[Route("/shirts/{id}")]
        public string UpdateShirts(int id)
        {
            return $"updating shirt id {id} from controller";

        }

        [HttpDelete("{id}")]
        //[Route("/shirts/{id}")]
        public string DeleteShirt(int id)
        {
            return $"deleting shirt {id} from controller";
        }
        
    }
}
