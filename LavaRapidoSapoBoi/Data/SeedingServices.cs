using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LavaRapidoSapoBoi.Models;
using LavaRapidoSapoBoi.Models.Enums;

namespace LavaRapidoSapoBoi.Data
{
    public class SeedingServices
    {

        private LavaRapidoSapoBoiContext _context;

        public SeedingServices(LavaRapidoSapoBoiContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departamento.Any() ||
                _context.Vendas.Any() ||
                _context.RegistroVendas.Any())
            {
                return; // DB has been seeded
            }

            Departamento d1 = new Departamento(3, "Polimento");
            Departamento d2 = new Departamento(4, "Lavagem");
            Departamento d3 = new Departamento(5, "Atendimento");
            Departamento d4 = new Departamento(6, "Marketing");


            Vendas v1 = new Vendas(1, "Juarez Jah", "juarez@gmail.com", new DateTime(1980, 4, 21), 1000.0, d1);
            Vendas v2 = new Vendas(2, "Suarez sah", "suarez@gmail.com", new DateTime(1984, 12, 31), 5000.0, d2);
            Vendas v3 = new Vendas(3, "Tamirez Tah", "Tamirez@gmail.com", new DateTime(1990, 5, 11), 8000.0, d1);
            Vendas v4 = new Vendas(4, "Jamirez Jah", "jamirez@gmail.com", new DateTime(1970, 6, 01), 4000.0, d4);
            Vendas v5 = new Vendas(5, "Andrez Jah", "Andrez@gmail.com", new DateTime(1988, 8, 22), 6000.0, d3);
            Vendas v6 = new Vendas(6, "Gonçalvez Jah", "gonçalvez@gmail.com", new DateTime(1980, 4, 21), 9000.0, d2);

            RegistroVendas r1 = new RegistroVendas(1, new DateTime(2022, 8, 15), 21000.0, StatusVendas.Vendas, v1);
            RegistroVendas r2 = new RegistroVendas(2, new DateTime(2022, 8, 10), 31000.0, StatusVendas.Vendas, v1);
            RegistroVendas r3 = new RegistroVendas(3, new DateTime(2022, 8, 11), 11200.0, StatusVendas.Vendas, v2);
            RegistroVendas r4 = new RegistroVendas(4, new DateTime(2022, 8, 12), 11200.0, StatusVendas.Vendas, v3);
            RegistroVendas r5 = new RegistroVendas(5, new DateTime(2022, 8, 13), 10000.0, StatusVendas.Vendas, v4);
            RegistroVendas r6 = new RegistroVendas(6, new DateTime(2022, 8, 14), 14000.0, StatusVendas.Vendas, v5);
            RegistroVendas r7 = new RegistroVendas(7, new DateTime(2022, 8, 15), 16000.0, StatusVendas.Vendas, v6);
            RegistroVendas r8 = new RegistroVendas(8, new DateTime(2022, 8, 16), 18000.0, StatusVendas.Vendas, v1);
            RegistroVendas r9 = new RegistroVendas(9, new DateTime(2022, 8, 17), 16000.0, StatusVendas.Vendas, v2);
            RegistroVendas r10 = new RegistroVendas(10, new DateTime(2022, 8, 05), 14000.0, StatusVendas.Vendas, v3);
            RegistroVendas r11 = new RegistroVendas(11, new DateTime(2022, 8, 25), 51000.0, StatusVendas.Vendas, v4);
            RegistroVendas r12 = new RegistroVendas(12, new DateTime(2022, 8, 03), 61000.0, StatusVendas.Vendas, v5);
            RegistroVendas r13 = new RegistroVendas(13, new DateTime(2022, 8, 13), 71000.0, StatusVendas.Vendas, v6);
            RegistroVendas r14 = new RegistroVendas(14, new DateTime(2022, 8, 14), 81000.0, StatusVendas.Vendas, v2);
            RegistroVendas r15 = new RegistroVendas(15, new DateTime(2022, 8, 22), 21000.0, StatusVendas.Vendas, v1);
            RegistroVendas r16 = new RegistroVendas(16, new DateTime(2022, 8, 15), 11000.0, StatusVendas.Vendas, v1);
            RegistroVendas r17 = new RegistroVendas(17, new DateTime(2022, 8, 15), 11000.0, StatusVendas.Vendas, v1);


            _context.Departamento.AddRange(d1, d2, d3, d4);
            _context.Vendas.AddRange(v1, v2, v3, v4, v5, v6);
            _context.RegistroVendas.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16, r17);

            _context.SaveChanges();
        }
    }
}
