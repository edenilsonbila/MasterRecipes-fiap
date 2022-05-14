using MasterRecipes.Data.Context;
using MasterRecipes.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace MasterRecipes.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Context _ctx;
        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _ctx = context;
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View(_ctx.Receitas.ToList());
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