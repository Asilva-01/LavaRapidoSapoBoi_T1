using System.Collections.Generic;


namespace LavaRapidoSapoBoi.Models.ViewModels
{
    public class VendasFormViewModels
    {

        public Vendas Vendas { get; set; }
        public ICollection<Departamento> Departaments { get; set; }
    }
}
