using LavaRapidoSapoBoi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavaRapidoSapoBoi.Services
{
    public class VendaService
    {

        private readonly LavaRapidoSapoBoiContext _context;

        public VendaService(LavaRapidoSapoBoiContext context)
        {
            _context = context;
        }

        public List<Vendas> FindAll()
        {
            return _context.Vendas.ToList();
        }

    }
}
