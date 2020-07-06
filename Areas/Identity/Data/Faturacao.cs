using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YURent.Areas.Identity.Data
{
    public class Faturacao
    {
        [Key]
        public int Id_faturacao { get; set; }

        public Utilizador Utilizador { get; set; }

        public string Nome_completo { get; set; }

        public string Morada { get; set; }

        public string Codigo_Postal { get; set; }

        public int Nif { get; set; }

        public string Iban { get; set; }

        public string Email { get; set; }

        public int Id_utilizador { get; set; }



    }
}
