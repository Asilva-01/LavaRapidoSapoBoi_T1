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

        public DbSet<LavaRapidoSapoBoi.Models.Departamento> Departamento { get; set; }
    }
}
