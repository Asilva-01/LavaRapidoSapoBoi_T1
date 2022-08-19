using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LavaRapidoSapoBoi.Models
{
    public class LavaRapidoSapoBoiContext : DbContext
    {
        public LavaRapidoSapoBoiContext (DbContextOptions<LavaRapidoSapoBoiContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamento { get; set; }

        public DbSet<Vendas> Vendas { get; set; }
        public DbSet<RegistroVendas> RegistroVendas { get; set; }
    }
}
