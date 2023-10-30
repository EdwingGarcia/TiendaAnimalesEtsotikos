using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TiendaAnimalesEtsotikos.Models;
using TiendaAnimalesEtsotikos.Services;

namespace TiendaAnimalesEtsotikos.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        public async Task<IActionResult> Index()
        {
            var animales = await _animalService.GetAllAnimales();
            return View(animales);
        }




        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Animal animal)
        {
            await _animalService.CreateAnimal(animal);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int Id)
        {
            var animal = await _animalService.GetAnimal(Id);
            if (animal != null) return View(animal);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int Id)
        {
            var animal = await _animalService.GetAnimal(Id);
            if (animal != null) return View(animal);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, Animal animal)
        {
            await _animalService.UpdateAnimal(Id, animal);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            _animalService.DeleteAnimal(Id);
            return RedirectToAction("Index");
        }

        [HttpGet("BuscarPorPropietario")]
        public async Task<IActionResult> BuscarPorPropietario(int Propietario)
        {
            var response = await _animalService.BuscarPorPropietario(Propietario);
            if (response != null)
            {
                return View("Index", response);
            }
            return RedirectToAction("Index");
        }

    }
}
