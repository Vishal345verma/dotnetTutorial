using ContosoPizza.Services;
using ContosoPizza.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {

        }

        [HttpGet]
        public ActionResult<List<Pizza>> GetAll()
        {
            Console.WriteLine("Got a call for get");
            return PizzaService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            return PizzaService.Get(id);
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.Id)
            {
                return BadRequest();
            }

            var existingPizza = PizzaService.Get(id);
            if (existingPizza == null) return NotFound();
            PizzaService.Update(pizza);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingPizza = PizzaService.Get(id);
            if (existingPizza == null) return NotFound();
            PizzaService.Delete(id);
            return NoContent();
        }
    }
}