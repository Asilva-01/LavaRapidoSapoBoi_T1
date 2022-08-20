using LavaRapidoSapoBoi.Models;
using LavaRapidoSapoBoi.Services;
using Microsoft.AspNetCore.Mvc;
using LavaRapidoSapoBoi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavaRapidoSapoBoi.Controllers
{
    public class VendasController : Controller
    {

        private readonly VendaService _vendaService;
        private readonly DepartamentoService _departamentoService;

        public VendasController(VendaService vendaService, DepartamentoService departamentoService)
        {
            _vendaService = vendaService;
            _departamentoService = departamentoService;
        }

        public IActionResult Index()
        {

            var list = _vendaService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departaments = _departamentoService.FinAll();
            var viewModel = new VendasFormViewModels { Departaments = departaments };
            
            
            return View(viewModel);

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
