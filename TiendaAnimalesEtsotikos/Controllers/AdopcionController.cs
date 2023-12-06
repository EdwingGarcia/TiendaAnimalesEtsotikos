using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using TiendaAnimalesEtsotikos.Models;
using TiendaAnimalesEtsotikos.Services;

namespace TiendaAnimalesEtsotikos.Controllers
{
    public class AdopcionController : Controller
    {
        private readonly IAnimalService _animalService;

        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://apianimalesadopcion.azurewebsites.net";

        public AdopcionController(IAnimalService animalService)
        {
            _animalService = animalService;

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_apiBaseUrl)
            };
        }


        public async Task<IActionResult> Index()
        {
            var animales = await _httpClient.GetFromJsonAsync<List<Animal>>("api/Animal");
           var animalesSoli = animales.Where(a => a.Status == 1).ToList();
          //  var animalesConPropietario = animales.Where(a => a.Propietario == "").ToList();
            return View(animalesSoli);
        }

        public async Task<IActionResult> Edit(int Id)
        {

            var animal = await _animalService.GetAnimal(Id);

            if (animal != null) return View(animal);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, Animal animal)
        {
            await _animalService.UpdateAnimal(Id, animal);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Aprobar(int id)
        {
            var animal = await _animalService.GetAnimal(id);


            animal.Status = 2;

            await _animalService.UpdateAnimal(id, animal);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Rechazar(int id)
        {
            var animal = await _animalService.GetAnimal(id);


            animal.Status = 0;
            animal.Propietario = "";

            await _animalService.UpdateAnimal(id, animal);
            return RedirectToAction("Index");
        }

    }
}
