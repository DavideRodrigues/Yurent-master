using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YURent.Areas.Identity.Data
{
    public class Guardados
    {
        [Key]
        public int Id_guardados { get; set; }
        public Utilizador Utilizador { get; set; }
        public Anuncios Anuncios { get; set; }
    }
}
