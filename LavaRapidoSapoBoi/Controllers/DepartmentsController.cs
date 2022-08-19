using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LavaRapidoSapoBoi.Models;

namespace LavaRapidoSapoBoi.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {

            List<Departamento> list = new List<Departamento>();
            list.Add(new Departamento { Id = 1, Name = "Comercial" });
            list.Add(new Departamento { Id = 2, Name = "Serviços" });

            return View(list);
        }
    }
}
