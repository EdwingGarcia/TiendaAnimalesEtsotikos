using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TiendaAnimalesEtsotikos.Models;

namespace TiendaAnimalesEtsotikos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StartIndex()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(int Cedula, string Password)
        {
            Cliente cliente = Util.Utils.ListaCliente.Find(x => x.Cedula == Cedula);
            if (cliente != null && Password == cliente.Password)
            {
                return View("Index");
            }
            ViewBag.ErrorMsg = "Cuenta no existente";
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        public IActionResult SignUp(Cliente cliente)
        {
            Util.Utils.ListaCliente.Add(cliente);
            ViewBag.ErrorMsg = "Cuenta creada";
            return RedirectToAction("Login");
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