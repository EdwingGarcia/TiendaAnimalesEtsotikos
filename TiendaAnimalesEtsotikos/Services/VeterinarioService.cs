using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using TiendaAnimalesEtsotikos.Models;
using TiendaAnimalesEtsotikos.Services;

namespace TiendaAnimalesEtsotikos.Services
{
    public class VeterinarioService : IVeterinarioService
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "http://localhost:5198";

        public VeterinarioService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_url)
            };
        }

        public async Task<List<Veterinario>> GetAllVeterinarios()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Veterinario>>("api/Veterinario");
            return response;
        }



        public async Task<Veterinario> GetVeterinario(string NombreVeterinario)
        {
            var response = await _httpClient.GetFromJsonAsync<Veterinario>($"api/Veterinario/{NombreVeterinario}");
            return response;
        }

        public async Task<Veterinario> CreateVeterinario(Veterinario veterinario)
        {

            var response = await _httpClient.PostAsJsonAsync("api/Veterinario", veterinario);
            return await response.Content.ReadFromJsonAsync<Veterinario>();
        }

        public async Task<Veterinario> UpdateVeterinario(string NombreVeterinario, Veterinario veterinario)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Veterinario/{NombreVeterinario}", veterinario);
            return await response.Content.ReadFromJsonAsync<Veterinario>();
        }

        public async void DeleteVeterinario(string NombreVeterinario)
        {
            _httpClient.DeleteAsync($"api/Animal/{NombreVeterinario}");
        }


    }
}
