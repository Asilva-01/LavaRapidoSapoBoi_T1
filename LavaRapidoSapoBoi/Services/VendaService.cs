using LavaRapidoSapoBoi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public void Insert(Vendas obj)
        {
          
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Vendas FindById(int id)

        {
            return _context.Vendas.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Vendas.Find(id);
            _context.Vendas.Remove(obj);
            _context.SaveChanges();
        }
    }
}
