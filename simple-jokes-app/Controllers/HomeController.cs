using simple_jokes_app.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using System.Linq;


namespace simple_jokes_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var getJokes = _context.Jokes.ToList();
            return View(getJokes);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Joke model)
        {
            if (ModelState.IsValid)
            {
                var joke = new Joke
                {
                    Comedian = model.Comedian,
                    Link = model.Link,
                    StandUp = model.StandUp
                };

                _context.Add(joke);
                _context.SaveChanges();

            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
