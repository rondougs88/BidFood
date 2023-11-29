using Microsoft.AspNetCore.Mvc;
using mvcApp2.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Xml.Linq;

namespace mvcApp2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Person person)
        {
            if (ModelState.IsValid)
            {
                string output = JsonConvert.SerializeObject(person);
                string tempFolder = Path.GetTempPath();
                var filePath = $"{tempFolder}request.json";
                System.IO.File.WriteAllText(filePath, output);

                ViewBag.Filepath = $"File saved in: {filePath}";
            }

            return View(person);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}