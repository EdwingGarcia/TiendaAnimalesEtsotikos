using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaAnimalesEtsotikos.Models;
using TiendaAnimalesEtsotikos.Util;

namespace TiendaAnimalesEtsotikos.Controllers
{
    public class ClienteController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:5198";

        public ClienteController()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_apiBaseUrl)
            };
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await _httpClient.GetFromJsonAsync<List<Cliente>>("api/Cliente");
            return View(clientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            await _httpClient.PostAsJsonAsync("api/Cliente", cliente);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int Cedula)
        {
            var cliente = await _httpClient.GetFromJsonAsync<Cliente>($"api/Cliente/{Cedula}");
            if (cliente != null) return View(cliente);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Cedula)
        {
            var cliente = await _httpClient.GetFromJsonAsync<Cliente>($"api/Cliente/{Cedula}");
            if (cliente != null) return View(cliente);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cliente cliente)
        {
            await _httpClient.PutAsJsonAsync($"api/Cliente/{cliente.Cedula}",cliente);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int Cedula)
        {
            await _httpClient.DeleteAsync($"api/Cliente/{Cedula}");
            return RedirectToAction("Index");
        }


     

    }
}
