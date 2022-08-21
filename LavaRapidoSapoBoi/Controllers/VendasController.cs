﻿using LavaRapidoSapoBoi.Models;
using LavaRapidoSapoBoi.Services;
using Microsoft.AspNetCore.Mvc;
using LavaRapidoSapoBoi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LavaRapidoSapoBoi.Services.Exceptions;

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

        public IActionResult Delete(int? id)
        {
            if(id == null )
            {
                return NotFound();
            }

            var obj = _vendaService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _vendaService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _vendaService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _vendaService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            List<Departamento> departamentos = _departamentoService.FinAll();
            VendasFormViewModels viewModel = new VendasFormViewModels { Vendas = obj, Departaments = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendas vendas)
        {
            if (id != vendas.Id)
            {
                return BadRequest();
            }

            try
            { 
            _vendaService.Update(vendas);
            return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}
