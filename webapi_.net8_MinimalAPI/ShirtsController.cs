using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi_.net8_MinimalAPI
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ShirtsController : ControllerBase
    {

        private List<ShirtModel> shirts = new List<ShirtModel>()
        {
        new ShirtModel { Id = 1, Brand = "Matsumi", Color="Greenish", Gender="Female", Price=21, Size=5},
         new ShirtModel { Id = 2, Brand = "Takusaki", Color="Purple", Gender="Male", Price=21, Size=6},
          new ShirtModel { Id = 3, Brand = "Finsuta", Color="Blue", Gender="Male", Price=21, Size=9},
           new ShirtModel { Id = 4, Brand = "Komansi", Color="Yellowish", Gender="Female", Price=21, Size=4}
        };

        [HttpGet]
        public string GetAllShirts() {
            return "getting from controller";
        }

        [HttpGet("{id}")]
        public IActionResult GetShirtBy(int id)
        {
            var shirtById= shirts.FirstOrDefault(x=>x.Id == id);
            if (shirtById == null)
                return NotFound();
            return Ok(shirtById);
            
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
