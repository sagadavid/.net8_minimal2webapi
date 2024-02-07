using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi_.net8_MinimalAPI
{
    [ApiController]
    public class ShirtsController : ControllerBase
    {
        [HttpGet]
        [Route("/shirts")]
        public string GetShirts() {
            return "getting from controller";
        }

        [HttpGet]
        [Route("/shirts/{id}")]
        public string GetShirtById(int id)
        {
            return $"getting shirt id {id} from controller";
        }

        [HttpPost]
        [Route("/shirts")]
        public string CreateShirt()
        {
            return $"creating shirts from controller";
        }

        [HttpPut]
        [Route("/shirts/{id}")]
        public string UpdateShirts(int id)
        {
            return $"updating shirt id {id} from controller";

        }

        [HttpDelete]
        [Route("/shirts/{id}")]
        public string DeleteShirt(int id)
        {
            return $"deleting from controller by id {id}";
        }
        
    }
}
