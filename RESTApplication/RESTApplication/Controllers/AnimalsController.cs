using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTApplication.Models;

namespace RESTApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        static private int _id = 0;
        static List<Animal> animals = new List<Animal>
        {
            new Animal()
            {
                Id = _id++,
                Name = "Psotka",
                Category = "Pies",
                Mass = 2.5f,
                Color = "Brązowy"
            },
            new Animal()
            {
                Id = _id++,
                Name = "Mamrotek",
                Category = "Kot",
                Mass = 2.1f,
                Color = "Czarny"
            },
            new Animal()
            {
                Id = _id++,
                Name = "Lenny",
                Category = "Ryba",
                Mass = 0.5f,
                Color = "Zielony"
            },
            new Animal()
            {
                Id = _id++,
                Name = "Jerry",
                Category = "Mysz",
                Mass = 0.2f,
                Color = "Brązowy"
            },
            new Animal()
            {
                Id = _id++,
                Name = "Miluś",
                Category = "Pies",
                Mass = 10.5f,
                Color = "Biały"
            }
        };
        
        // GET api/animals
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(animals);
        }
        
        // GET: https://localhost:XXXX/api/animals/{id}
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var animal = animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }
        
        // POST: https://localhost:XXXX/api/animals
        [HttpPost]
        public IActionResult Create([FromBody] Animal animal)
        {
            var animalToBeCrated = new Animal
            {
                Id = _id++,
                Name = animal.Name,
                Category = animal.Category,
                Color = animal.Color,
                Mass = animal.Mass,
            };
            animals.Add(animalToBeCrated); // Zasymulowane dodanie rekordu do BD
            return CreatedAtAction(nameof(GetById), new { id = animalToBeCrated.Id }, animalToBeCrated);
        }
        
        // PUT: https://localhost:XXXX/api/animals/{id}
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Animal animal)
        {
            var animalToBeUpdated = animals.FirstOrDefault(a => a.Id == id);
            if (animalToBeUpdated == null)
            {
                return NotFound();
            }

            //Zasymulowanie modyfikacji rekordu w BD
            var postedAnimal = animals[id] = new Animal
            {
                Id = id,
                Name = animal.Name,
                Category = animal.Category,
                Mass = animal.Mass,
                Color = animal.Color
            };

            return Ok(postedAnimal);
        }
        
        // DELETE: https://localhost:XXXX/api/animals/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var animalToBeDeleted = animals.FirstOrDefault(a => a.Id == id);
            if (animalToBeDeleted == null)
            {
                return NotFound();
            }

            //Zasymulowanie usunięcie rekordu w BD
            animals.RemoveAt(animalToBeDeleted.Id);

            return Ok(animalToBeDeleted);
        }
        
        // GET: https://localhost:XXXX/api/animals/{name}
        [HttpGet]
        [Route("{name}")]
        public IActionResult GetByName([FromRoute] string name)
        {
            var animalFound = animals.Where(a => a.Name == name).ToList();
            if (animalFound == null)
            {
                return NotFound();
            }

            return Ok(animalFound);
        }
    }
}
