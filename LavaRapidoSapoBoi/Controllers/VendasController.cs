using LavaRapidoSapoBoi.Models;
using LavaRapidoSapoBoi.Services;
using Microsoft.AspNetCore.Mvc;
using LavaRapidoSapoBoi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LavaRapidoSapoBoi.Services.Exceptions;
using System.Diagnostics;

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

        public async Task <IActionResult> Index()
        {

            var list = await _vendaService.FindAllAsync();
            return View(list);
        }

        public async Task <IActionResult> Create()
        {
            var departaments = await _departamentoService.FinAllAsync();
            var viewModel = new VendasFormViewModels { Departaments = departaments };
            
            
            return View(viewModel);

        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Vendas vendas)
        {
            if (!ModelState.IsValid)
            {
                var departaments = await _departamentoService.FinAllAsync();
                var viewModel = new VendasFormViewModels { Vendas = vendas, Departaments = departaments };
                return View(viewModel);
            }


            await _vendaService.InsertAsync(vendas);
            return RedirectToAction(nameof(Index));

        }

        public async Task <IActionResult> Delete(int? id)
        {
            if(id == null )
            {
                return RedirectToAction(nameof(Error), new { message = "Número de cadastro não informado" });
            }

            var obj = await _vendaService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Cadastro não existente" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)



        {

            try
            {
                await _vendaService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));

            }

            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
            
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Número de cadastro não informado" });
            }

            var obj = await _vendaService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Cadastro não existente" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Número de cadastro não informado" });
            }

            var obj = await _vendaService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Cadastro não existente" });
            }

            List<Departamento> departamentos = await _departamentoService.FinAllAsync();
            VendasFormViewModels viewModel = new VendasFormViewModels { Vendas = obj, Departaments = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendas vendas)
        {
            if (!ModelState.IsValid)
            {
                var departaments = await _departamentoService.FinAllAsync();
                var viewModel = new VendasFormViewModels { Vendas = vendas, Departaments = departaments};
                return View(viewModel);
            }


            if (id != vendas.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Número de cadastro incorreto!" });
            }

            try
            { 
            await _vendaService.UpdateAsync(vendas);
            return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

    }
}
