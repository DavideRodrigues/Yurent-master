using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YURent.Areas.Identity.Data
{
    public class Verificacao
    {
        [Key]
        public int Id_verificacao { get; set; }
        public string Telemovel { get; set; }
        public string Num_cc { get; set; }

        public string Email { get; set; }

        public Utilizador Utilizador { get; set; }

    }
}
