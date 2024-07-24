using Microsoft.AspNetCore.Mvc;
using PizzaParty.Models;

namespace PizzaParty.Controllers
{
    public class EventController : Controller
    {

        private readonly IEventRepository repo;

        public EventController(IEventRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var party = repo.GetAllEvents();
            return View(party);
        }

        public IActionResult ViewEvent(int id)
        {
            var party = repo.GetEvent(id);
            return View(party);
        }

        public IActionResult UpdateEvent(int id)
        {
            Events party= repo.GetEvent(id);
        if (party == null)
        {
            return View("EventNotFound");
        }
            return View(party);
        }

        public IActionResult UpdateEventToDatabase(Events party)
        {
            repo.UpdateEvent(party);

            return RedirectToAction("ViewEvent", new { id = party.EventID });
        }


        public IActionResult InsertEvent()
        {
            var party = repo.AssignCategory();
            return View(party);


        }

        public IActionResult InsertEventToDatabase(Events eventToInsert)
        {
            repo.InsertEvent(eventToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEvent(Events party)
        {
            repo.DeleteEvent(party);
            return RedirectToAction("Index");
        }




        
    }
}


