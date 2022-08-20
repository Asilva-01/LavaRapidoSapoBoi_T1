using System;
using System.Collections.Generic;
using System.Linq;

namespace LavaRapidoSapoBoi.Models
{
    public class Departamento
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Vendas> Vendas { get; set; } = new List<Vendas>();
     

        public Departamento()
        {

        }

        public Departamento(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddVendas(Vendas vendas)
        {
            Vendas.Add(vendas);
        }

        public double TotalVendas(DateTime initial, DateTime final)
        {
            return Vendas.Sum(vendas => vendas.TotalVendas(initial, final));
        }
    }   
}
