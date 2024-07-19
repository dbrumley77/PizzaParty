using Microsoft.AspNetCore.Mvc;
using PizzaParty.Models;

namespace PizzaParty.Controllers
{
    public class PersonController : Controller
    {
        

            private readonly IPersonRepository repo;

            public PersonController(IPersonRepository repo)
            {
                this.repo = repo;
            }


            public IActionResult Index()
            {
                var people = repo.GetAllPerson();
                return View(people);
            }

            public IActionResult ViewPerson(int id)
            {
                var people = repo.GetPerson(id);
                return View(people);
            }

            public IActionResult UpdatePerson(int id)
            {
                PizzaPerson person = repo.GetPerson(id);
                if (person == null)
                {
                    return View("PersonNotFound");
                }
                return View(person);
            }

            public IActionResult UpdatePersonToDatabase(PizzaPerson person)
            {
                repo.UpdatePerson(person);

                return RedirectToAction("ViewPerson", new { id = person.CustomerID });
            }

            public IActionResult InsertPerson()
            {
                var person = repo.AssignCategory();
                return View(person);
            }

            public IActionResult InsertPersonToDatabase(PizzaPerson personToInsert)
            {
                repo.InsertPerson(personToInsert);
                return RedirectToAction("Index");
            }

            public IActionResult DeletePerson(PizzaPerson person)
            {
                repo.DeletePerson(person);
                return RedirectToAction("Index");
            }




        
    }



}





