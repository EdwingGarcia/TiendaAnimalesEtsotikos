using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaAnimalesEtsotikos.Models;

namespace TiendaAnimalesEtsotikos.Controllers
{
    public class VeterinarioController : Controller
    {
        // GET: veterinarioController
        public IActionResult Index()
        {
            return View(Util.Utils.ListaVeterinario);
        }

        // GET: veterinarioController/Details/5
        public IActionResult Details(string NombreVeterinario)
        {
            Veterinario veterinario = Util.Utils.ListaVeterinario.Find(x => x.NombreVeterinario == NombreVeterinario);
            if (veterinario != null)
            {
                return View(veterinario);
            }
            return RedirectToAction("Index");
        }

        // GET: veterinarioController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: veterinarioController/Create
        [HttpPost]
        public IActionResult Create(Veterinario veterinario)
        {
            Util.Utils.ListaVeterinario.Add(veterinario);
            return RedirectToAction("Index");
        }


        // GET: veterinarioController/Edit/5
        public IActionResult Edit(string NombreVeterinario)
        {
            Veterinario veterinario = Util.Utils.ListaVeterinario.Find(x => x.NombreVeterinario == NombreVeterinario);
            if (veterinario != null)
            {
                return View(veterinario);
            }
            return RedirectToAction("Index");
        }

        // POST: veterinarioController/Edit/5
        [HttpPost]
        public IActionResult Edit(Veterinario veterinario)
        {
            Veterinario veterinario2 = Util.Utils.ListaVeterinario.Find(x => x.NombreVeterinario == veterinario.NombreVeterinario);
            if (veterinario2 != null)
            {
                veterinario2.NombreVeterinario = veterinario.NombreVeterinario;
                veterinario2.DireccionVeterinario = veterinario.DireccionVeterinario;
                veterinario2.TelefonoVeterinario = veterinario.TelefonoVeterinario;

                return RedirectToAction("Index");
            }
            return View(veterinario);

        }

        // GET: veterinarioController/Delete/5
        public IActionResult Delete(string NombreVeterinario)
        {
            Veterinario veterinario = Util.Utils.ListaVeterinario.Find(x => x.NombreVeterinario == NombreVeterinario);
            if (veterinario != null)
            {
                Util.Utils.ListaVeterinario.Remove(veterinario);
                //return View();
            }
            return RedirectToAction("Index");
        }
    }
}
