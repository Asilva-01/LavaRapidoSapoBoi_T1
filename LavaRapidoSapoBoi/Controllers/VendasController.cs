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
    }
}
