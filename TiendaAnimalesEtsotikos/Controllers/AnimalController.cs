using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TiendaAnimalesEtsotikos.Models;

namespace TiendaAnimalesEtsotikos.Controllers
{
    public class AnimalController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:5198";

        public AnimalController()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_apiBaseUrl)
            };
        }

        public async Task<IActionResult> Index()
        {
            var animales = await _httpClient.GetFromJsonAsync<List<Animal>>("api/Animal");
            return View(animales);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Animal animal)
        {
            await _httpClient.PostAsJsonAsync("api/Animal", animal);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var animal = await _httpClient.GetFromJsonAsync<Animal>($"api/Animal/{id}");
            if (animal != null) return View(animal);
            return RedirectToAction("Index");
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

        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Animal/{id}");
            return RedirectToAction("Index");
        }

        [HttpGet("BuscarPorPropietario")]
        public async Task<IActionResult> BuscarPorPropietario(int Propietario)
        {
            if(Propietario != 0) {
                var response = await _httpClient.GetFromJsonAsync<List<Animal>>($"api/Animal/GetAnimalesPorCedula/{Propietario}");
                if (response != null)
                {
                    return View("Index", response);
                }
            }
            return RedirectToAction("Index");
        }

    }
}
