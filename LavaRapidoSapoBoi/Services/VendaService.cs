using LavaRapidoSapoBoi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LavaRapidoSapoBoi.Services.Exceptions;

namespace LavaRapidoSapoBoi.Services
{
    public class VendaService
    {

        private readonly LavaRapidoSapoBoiContext _context;

        public VendaService(LavaRapidoSapoBoiContext context)
        {
            _context = context;
        }

        public async Task<List<Vendas>> FindAllAsync()
        {
            return await _context.Vendas.ToListAsync();
        }

        public async Task InsertAsync(Vendas obj)
        {

            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Vendas> FindByIdAsync(int id)

        {
            return await _context.Vendas.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)


        {
            try
            {
                var obj = await _context.Vendas.FindAsync(id);
                _context.Vendas.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Já existe vendas associada ao cadastro, não será possível excluir o registro");
            }
        }
        public async Task UpdateAsync(Vendas obj)
        {
            bool hasAny = await _context.Vendas.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();

            }

            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);

            }
        }
    }
}
