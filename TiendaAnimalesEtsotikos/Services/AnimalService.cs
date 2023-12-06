using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using TiendaAnimalesEtsotikos.Models;

namespace TiendaAnimalesEtsotikos.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "https://apianimalesadopcion.azurewebsites.net";

        public AnimalService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_url)
            };
        }

        public async Task<List<Animal>> GetAllAnimales()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Animal>>("api/Animal");
            return response;
        }

        public async Task<Animal> GetAnimal(int Id)
        {
            var response = await _httpClient.GetFromJsonAsync<Animal>($"api/Animal/{Id}");
            return response;
        }

        public async Task<Animal> CreateAnimal(Animal animal)
        {
            animal.Status = 0;
            animal.Propietario="";
            var response = await _httpClient.PostAsJsonAsync("api/Animal", animal);
            Console.WriteLine(response.Content.ReadAsStringAsync());
            if(response!=null) { return await response.Content.ReadFromJsonAsync<Animal>(); }return null;

        }

        public async Task<Animal> UpdateAnimal(int Id, Animal animal)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Animal/{Id}", animal);
            return await response.Content.ReadFromJsonAsync<Animal>();
        }

        public async Task DeleteAnimal(int Id)
        {
            var response = await _httpClient.DeleteAsync($"api/Animal/{Id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Animal>> BuscarPorPropietario(int Propietario)
        {
            if (Propietario != 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<Animal>>($"api/Animal/GetAnimalesPorCedula/{Propietario}");
                return response;
            }
            else
            {
                // Considera lanzar una excepción o devolver un código de estado HTTP apropiado aquí
                // en lugar de devolver null.
                throw new ArgumentException("Propietario no válido.");
            }
        }
    }
}
