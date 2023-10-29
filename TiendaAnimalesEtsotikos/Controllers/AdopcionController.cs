using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaAnimalesEtsotikos.Models;

namespace TiendaAnimalesEtsotikos.Controllers
{
    public class AdopcionController : Controller
    {
        // GET: AdopcionController
        public IActionResult Index()
        {
            return View(Util.Utils.ListaCliente);
        }



        public IActionResult Edit(int Cedula)
        {
            Cliente cliente = Util.Utils.ListaCliente.Find(x => x.Cedula == Cedula);
            if (cliente != null)
            {
                return View(cliente);
            }
            return RedirectToAction("Index");
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            Cliente cliente2 = Util.Utils.ListaCliente.Find(x => x.Cedula == cliente.Cedula);
            if (cliente2 != null)
            {
                cliente2.AnimalComprado = cliente.AnimalComprado;

                return RedirectToAction("Index");
            }
            return View(cliente);

        }




    }
}
