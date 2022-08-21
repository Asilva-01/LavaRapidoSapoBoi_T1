using LavaRapidoSapoBoi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LavaRapidoSapoBoi.Controllers;

namespace LavaRapidoSapoBoi.Services
{
    public class VendasRecordsService

    {

        private readonly LavaRapidoSapoBoiContext _context;

        public VendasRecordsService(LavaRapidoSapoBoiContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroVendas>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.RegistroVendas select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }

            return await result
                .Include(x => x.Vendas)
                .Include(x => x.Vendas.Departamento)
                .OrderByDescending(x => x.Data)
                .ToListAsync();

        }

        public static implicit operator VendasRecordsService(VendasRecordsController v)
        {
            throw new NotImplementedException();
        }
    }
    }


