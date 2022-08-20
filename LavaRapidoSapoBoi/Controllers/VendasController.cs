using LavaRapidoSapoBoi.Models;
using LavaRapidoSapoBoi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavaRapidoSapoBoi.Controllers
{
    public class VendasController : Controller
    {

        private readonly VendaService _vendaService;

        public VendasController(VendaService vendaService)
        {
            _vendaService = vendaService;
        }

        public IActionResult Index()
        {

            var list = _vendaService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();

        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Vendas vendas)
        {
            _vendaService.Insert(vendas);
            return RedirectToAction(nameof(Index));

        }
    }
}
