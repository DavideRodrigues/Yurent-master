using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YURent.Models
{
    public class GuardadosModel
    {
        [Key]
        public int Id_guardados { get; set; }
        public UtilizadorModel Utilizador { get; set; }
        public AnunciosModel Anuncios { get; set; }

    }
}
