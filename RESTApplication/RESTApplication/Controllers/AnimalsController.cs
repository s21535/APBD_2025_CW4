using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTApplication.Models;

namespace RESTApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        List<Animal> animals = new List<Animal>
        {
            new Animal()
            {
                Id = 1,
                Name = "Psotka",
                Category = "Pies",
                Mass = 2.5f,
                Color = "Brązowy"
            },
            new Animal()
            {
                Id = 2,
                Name = "Mamrotek",
                Category = "Kot",
                Mass = 2.1f,
                Color = "Czarny"
            },
            new Animal()
            {
                Id = 3,
                Name = "Lenny",
                Category = "Ryba",
                Mass = 0.5f,
                Color = "Zielony"
            },
            new Animal()
            {
                Id = 4,
                Name = "Jerry",
                Category = "Mysz",
                Mass = 0.2f,
                Color = "Brązowy"
            },
            new Animal()
            {
                Id = 5,
                Name = "Miluś",
                Category = "Pies",
                Mass = 10.5f,
                Color = "Biały"
            }
        };
        
        //GET api/animals
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(animals);
        }
    }
}
