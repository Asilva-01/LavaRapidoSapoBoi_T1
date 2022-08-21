using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LavaRapidoSapoBoi.Models
{
    public class Vendas
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo {0} deve ser informado")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Campo {0}  deve conter no mínimo {2} ou no máximo {1} caracteres !")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informar um endereço de {0}")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informar a {0} ")]
        [Display(Name ="Data Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Informar o valor de {0}")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [Display(Name = "Salário Base")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double SalarioBase { get; set; }

        
        public Departamento Departamento { get; set; }

        
        [Display(Name = "Departamento")]
        public int DepartamentoId{ get; set; }

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
