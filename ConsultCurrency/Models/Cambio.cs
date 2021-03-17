using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultCurrency.Models
{
    public class Cambio
    {
        [Key]
        public int ID_CAMBIO { get; set; }
        public int MoedaID_MOEDA { get; set; }
        public decimal VL_CAMBIO { get; set; }

        public virtual Moeda Moeda { get; set; }
    }
}
