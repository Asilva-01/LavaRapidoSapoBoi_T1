using LavaRapidoSapoBoi.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace LavaRapidoSapoBoi.Models
{
    public class RegistroVendas
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double Quantidade { get; set; }
        public StatusVendas Status{ get; set; }
        public Vendas Vendas { get; set; }


        public RegistroVendas()
        {

        }

        public RegistroVendas(int id, DateTime data, double quantidade, StatusVendas status, Vendas vendas)
        {
            Id = id;
            Data = data;
            Quantidade = quantidade;
            Status = status;
            Vendas = vendas;
        }
    }
}
