using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using TiendaAnimalesEtsotikos.Models;

namespace TiendaAnimalesEtsotikos.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://apianimalesadopcion.azurewebsites.net";



        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_apiBaseUrl)
            };
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
        public async Task<IActionResult> Login(int Cedula, string Password)
        {
            var cliente = await _httpClient.GetFromJsonAsync<Cliente>($"api/Cliente/{Cedula}");
            if (cliente != null && Password == cliente.Password)
            {
                return View("Index");
            }
            ViewBag.ErrorMsg = "Cuenta no existente";
            return View();
        }









        [HttpPost]
        public async Task<IActionResult> SignUp(Cliente cliente)
        {
            await _httpClient.PostAsJsonAsync("api/Cliente", cliente);
            return RedirectToAction("Index");
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