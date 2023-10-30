using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using TiendaAnimalesEtsotikos.Models;

namespace TiendaAnimalesEtsotikos.Controllers
{
    public class AdopcionController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:5198";

        public AdopcionController()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_apiBaseUrl)
            };
        }


        public async Task<IActionResult> Index()
        {
            var animales = await _httpClient.GetFromJsonAsync<List<Animal>>("api/Animal");
            var animalesConPropietario = animales.Where(a => a.Propietario == null).ToList();
            return View(animalesConPropietario);
        }






    }
}
