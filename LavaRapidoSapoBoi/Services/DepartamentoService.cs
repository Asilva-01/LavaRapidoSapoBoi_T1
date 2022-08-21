using LavaRapidoSapoBoi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LavaRapidoSapoBoi.Services
{
    public class DepartamentoService
    {
       
            private readonly LavaRapidoSapoBoiContext _context;

            public DepartamentoService(LavaRapidoSapoBoiContext context)
            {
                _context = context;
            }

            public async Task<List<Departamento>> FinAllAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Name).ToListAsync();
        }
        }
}
