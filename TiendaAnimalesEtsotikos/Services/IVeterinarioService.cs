using Microsoft.AspNetCore.Mvc;
using TiendaAnimalesEtsotikos.Models;

namespace TiendaAnimalesEtsotikos.Services
{
    public interface IVeterinarioService
    {
        Task<List<Veterinario>> GetAllVeterinarios();
        Task<Veterinario> GetVeterinario(string NombreVeterinario);
        Task<Veterinario> CreateVeterinario(Veterinario veterinario);
        Task<Veterinario> UpdateVeterinario(string NombreVeterinario, Veterinario veterinario);
        void DeleteVeterinario(string NombreVeterinario);
     


    }
}
