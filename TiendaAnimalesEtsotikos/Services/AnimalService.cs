using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using TiendaAnimalesEtsotikos.Models;
using TiendaAnimalesEtsotikos.Services;

namespace TiendaAnimalesEtsotikos.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "http://localhost:5198";

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

            var response = await _httpClient.PostAsJsonAsync("api/Animal", animal);
            return await response.Content.ReadFromJsonAsync<Animal>();
        }

        public async Task<Animal> UpdateAnimal(int Id, Animal animal)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Animal/{Id}", animal);
            return await response.Content.ReadFromJsonAsync<Animal>();
        }

        public async void DeleteAnimal(int Id)
        {
            _httpClient.DeleteAsync($"api/Animal/{Id}");
        }


        [HttpGet("BuscarPorPropietario")]
        public async Task<List<Animal>> BuscarPorPropietario(int Propietario)
        {
            if (Propietario != 0)
            {

                var response = await _httpClient.GetFromJsonAsync<List<Animal>>($"api/Animal/GetAnimalesPorCedula/{Propietario}");
                return response;
            }
            return null;
        }
    }
}
