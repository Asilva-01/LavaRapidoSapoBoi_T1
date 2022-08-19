using LavaRapidoSapoBoi.Models.Enums;
using System;


namespace LavaRapidoSapoBoi.Models
{
    public class RegistroVendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
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
