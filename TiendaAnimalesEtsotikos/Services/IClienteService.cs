using Microsoft.AspNetCore.Mvc;
using TiendaAnimalesEtsotikos.Models;

namespace TiendaAnimalesEtsotikos.Services
{
    public interface IClienteService
    {
        Task<List<Cliente>> GetAllClientes();
        Task<Cliente> GetCliente(int Cedula);
        Task<Cliente> CreateCliente(Cliente cliente);
        Task<Cliente> UpdateCliente(int Cedula, Cliente cliente);
        void DeleteCliente(int Cedula);




    }
}
