using LavaRapidoSapoBoi.Models;
using System.Collections.Generic;
using System.Linq;


namespace LavaRapidoSapoBoi.Services
{
    public class DepartamentoService
    {
       
            private readonly LavaRapidoSapoBoiContext _context;

            public DepartamentoService(LavaRapidoSapoBoiContext context)
            {
                _context = context;
            }

            public List<Departamento> FinAll()
        {
            return _context.Departamento.OrderBy(x => x.Name).ToList();
        }
        }
}
