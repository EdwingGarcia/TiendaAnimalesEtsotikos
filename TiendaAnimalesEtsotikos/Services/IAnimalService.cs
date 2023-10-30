using Microsoft.AspNetCore.Mvc;
using TiendaAnimalesEtsotikos.Models;

namespace TiendaAnimalesEtsotikos.Services
{
    public interface IAnimalService
    {
        Task<List<Animal>> GetAllAnimales();
        Task<Animal> GetAnimal(int Id);
        Task<Animal> CreateAnimal(Animal animal);
        Task<Animal> UpdateAnimal(int Id, Animal animal);
        Task DeleteAnimal(int Id);
        Task<List<Animal>> BuscarPorPropietario(int Propietario);



    }
}
