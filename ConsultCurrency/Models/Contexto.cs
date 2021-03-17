using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultCurrency.Models
{
    [NotMapped]
    public class Contexto 
    {
        public decimal cotacaoCompra { get; set; }        
        public int idMoeda { get; set; }
        public string data { get; set; }      
    }

    public class Valor
    {
        public List<Contexto> value { get; set; }
    }
}
