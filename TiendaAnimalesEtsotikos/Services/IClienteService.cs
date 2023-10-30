using Microsoft.AspNetCore.Mvc;
using TiendaAnimalesEtsotikos.Models;

namespace TiendaAnimalesEtsotikos.Services
{
    public interface IClienteService
    {
        Task<List<Cliente>> GetAllClientes();
        Task<Cliente> GetCliente(string Cedula);
        Task<Cliente> CreateCliente(Cliente cliente);
        Task<Cliente> UpdateCliente(string Cedula, Cliente cliente);
        void DeleteCliente(string Cedula);




    }
}
