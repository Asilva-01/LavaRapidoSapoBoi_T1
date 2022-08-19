using System;
using System.Collections.Generic;
using System.Linq;

namespace LavaRapidoSapoBoi.Models
{
    public class Vendas
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public double SalarioBase { get; set; }

        public Departamento Departamento { get; set; }

        public ICollection<RegistroVendas> Venda { get; set; } = new List<RegistroVendas>();


        public Vendas()
        {

        }

        public Vendas(int id, string nome, string email, DateTime dataNascimento, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AddVendas(RegistroVendas rv)
        {
            Venda.Add(rv);
        }

        public void RemoveVendas(RegistroVendas rv)
        {
            Venda.Remove(rv);
        }

        public double TotalVendas(DateTime initial, DateTime final) 
        {

            return Venda.Where(rv => rv.Data >= initial && rv.Data <= final).Sum(rv => rv.Quantidade); 

        }
    }
}
