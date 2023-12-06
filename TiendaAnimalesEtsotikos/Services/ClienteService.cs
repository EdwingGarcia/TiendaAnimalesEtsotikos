using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using TiendaAnimalesEtsotikos.Models;
using TiendaAnimalesEtsotikos.Services;
using static System.Net.WebRequestMethods;

namespace TiendaAnimalesEtsotikos.Services
{
    public class ClienteService : IClienteService
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "https://apianimalesadopcion.azurewebsites.net";

        public ClienteService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_url)
            };
        }

        public async Task<List<Cliente>> GetAllClientes()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Cliente>>("api/Cliente");
            return response;
        }



        public async Task<Cliente> GetCliente(string Cedula) { 
            var response = await _httpClient.GetFromJsonAsync<Cliente>($"api/Cliente/{Cedula}");
            return response;
        }

        public async Task<Cliente> CreateCliente(Cliente cliente)
        {

            var response = await _httpClient.PostAsJsonAsync("api/Cliente", cliente);
            return await response.Content.ReadFromJsonAsync<Cliente>();
        }

        public async Task<Cliente> UpdateCliente(string Cedula, Cliente cliente)
        {
            cliente.Password = string.Empty;
            var response = await _httpClient.PutAsJsonAsync($"api/Cliente/{Cedula}", cliente);
            return await response.Content.ReadFromJsonAsync<Cliente>();
        }

        public async void DeleteCliente(string Cedula)
        {
            _httpClient.DeleteAsync($"api/Cliente/{Cedula}");
        }


 



        public async Task<List<Cliente>> BuscarCedula(string Cedula)
        {
                var response = await _httpClient.GetFromJsonAsync<List<Cliente>>($"api/Cliente/BuscarCedula/{Cedula}");
               return response;

        }

    }
}
