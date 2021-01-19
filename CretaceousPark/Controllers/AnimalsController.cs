using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CretaceousPark.Models;

namespace CretaceousPark.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private CretaceousParkContext _db;

    public AnimalsController(CretaceousParkContext db)
    {
      _db = db;
    }

    // GET api/animals
    [HttpGet]
    public ActionResult<IEnumerable<Animal>> Get()
    {
      return _db.Animals.ToList();
    }

    // POST api/animals
    [HttpPost]
    public void Post([FromBody] Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
    }

    // GET api/animals/5 --- getting a 404
    [HttpGet("{id}")]
    public ActionResult<Animal> Get(int id)
    {
      return _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
    }
  }
}

// The key difference between this API app and a MVC webapp is that we do not return a View()

// Our GET route needs to return an ActionResult of type <IEnumerable<Animal>>. In our web applications, we didn't need to specify a type because we were always returning a view

// We need to include the [FromBody] annotation so that we can actually put the details of a new animal in the body of a POST API call