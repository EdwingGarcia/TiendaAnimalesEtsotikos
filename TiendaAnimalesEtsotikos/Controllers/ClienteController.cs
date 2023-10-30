using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaAnimalesEtsotikos.Models;
using TiendaAnimalesEtsotikos.Services;


namespace TiendaAnimalesEtsotikos.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteService.GetAllClientes();
            return View(clientes);
        }




        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            await _clienteService.CreateCliente(cliente);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string Cedula)
        {
            var cliente = await _clienteService.GetCliente(Cedula);
            if (cliente != null) return View(cliente);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(string Cedula)
        {
            var cliente = await _clienteService.GetCliente(Cedula);
            if (cliente != null) return View(cliente);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string Cedula, Cliente cliente)
        {
            var response= await _clienteService.UpdateCliente(Cedula, cliente);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string Cedula)
        {
            _clienteService.DeleteCliente(Cedula);
            return RedirectToAction("Index");
        }

        [HttpGet("BuscarCedula")]
        public async Task<IActionResult> BuscarCedula(string Cedula)
        {
            var response = await _clienteService.BuscarCedula(Cedula);
            if (response != null)
            {
                return View("Index", response);
            }
            return RedirectToAction("Index");
        }


    }
}
