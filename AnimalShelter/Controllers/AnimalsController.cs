using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;                 //This will allow us to use LINQ's ToList() method

namespace AnimalShelter.Controllers
{
  public class AnimalsController : Controller
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Animal> model = _db.Animals.ToList();  // access all our Animals in List
      return View(model);
    }

    public ActionResult Create()  //GET route New() to create form 
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
        _db.Animals.Add(animal);       
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animal => animal.Id == id);  // animal.Id == id from the database
      return View(thisAnimal);
    }
  }
}