using Microsoft.AspNetCore.Mvc;

namespace PizzaParty.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ILogger<PeopleController> _logger;

        public PeopleController(ILogger<PeopleController> logger)
        {
            _logger = logger;
        }


    }




}
