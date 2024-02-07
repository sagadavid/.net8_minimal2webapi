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

        [HttpGet("{id}")]
        //[Route("/shirts/{id}")]
        public string GetShirtBy(int id)
        {
            return $"getting shirt id {id} from controller";
        }

        [HttpPost]
        //[Route("/shirts")]
        public string CreateShirt([FromForm]ShirtModel shirt)
        {
            return $"creating shirts from controller";
        }

        [HttpPut("{id}")]
        //[Route("/shirts/{id}")]
        public string UpdateShirtBy(int id)
        {
            return $"updating shirt id {id} from controller";

        }

        [HttpDelete("{id}")]
        //[Route("/shirts/{id}")]
        public string DeleteShirtBy(int id)
        {
            return $"deleting shirt {id} from controller";
        }
        
    }
}
