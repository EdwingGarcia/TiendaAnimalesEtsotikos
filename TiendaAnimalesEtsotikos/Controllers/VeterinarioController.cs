using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaAnimalesEtsotikos.Models;

namespace TiendaAnimalesEtsotikos.Controllers
{
    public class VeterinarioController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:5198";

        public VeterinarioController()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_apiBaseUrl)
            };
        }

        public async Task<IActionResult> Index()
        {
            var veterinarios = await _httpClient.GetFromJsonAsync<List<Veterinario>>("api/Veterinario");
            return View(veterinarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Veterinario veterinario)
        {
            await _httpClient.PostAsJsonAsync("api/Veterinario", veterinario);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string NombreVeterinario)
        {
            var veterinario = await _httpClient.GetFromJsonAsync<Veterinario>($"api/Veterinario/{NombreVeterinario}");
            if (veterinario != null) return View(veterinario);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string NombreVeterinario)
        {
            var veterinario = await _httpClient.GetFromJsonAsync<Veterinario>($"api/Veterinario/{NombreVeterinario}");
            if (veterinario != null) return View(veterinario);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Veterinario veterinario)
        {
            await _httpClient.PutAsJsonAsync($"api/Veterinario/{veterinario.NombreVeterinario}", veterinario);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string NombreVeterinario)
        {
            await _httpClient.DeleteAsync($"api/Veterinario/{NombreVeterinario}");
            return RedirectToAction("Index");
        }

    }
}
