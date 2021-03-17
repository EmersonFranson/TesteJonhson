using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultCurrency.Models
{
    public class Moeda
    {
        [Key]
        public int ID_MOEDA { get; set; }
        public string DS_MOEDA { get; set; }
    }
}
