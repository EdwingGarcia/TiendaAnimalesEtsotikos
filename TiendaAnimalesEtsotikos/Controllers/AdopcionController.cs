using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using TiendaAnimalesEtsotikos.Models;

namespace TiendaAnimalesEtsotikos.Controllers
{
    public class AdopcionController : Controller
    {
        // GET: AdopcionController
        public IActionResult Index()
        {
            return View(Util.Utils.ListaCliente);
        }

        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:5198";

        public AdopcionController()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_apiBaseUrl)
            };
        }

        public async Task<IActionResult> Edit(int id)
        {
            var animal = await _httpClient.GetFromJsonAsync<Animal>($"api/Animal/{id}");
            if (animal != null) return View(animal);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Animal animal)
        {
            await _httpClient.PutAsJsonAsync($"api/Animal/{animal.Id}", animal);
            return RedirectToAction("Index");
        }



    }
}
