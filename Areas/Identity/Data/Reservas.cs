using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YURent.Areas.Identity.Data
{
    public class Reservas
    {
        [Key]
        public int Id_reserva { get; set; }
        [ForeignKey("Id_anuncio")]
        public int Id_anuncio { get; set; }
        [ForeignKey("Id")]
        public int Id { get; set; }
        public DateTime Data_inicio { get; set; }
        public DateTime Data_fim { get; set; }
        public float Preco { get; set; }
        public bool Cancelado { get; set; }

        public int Id_utilizador { get; set; }

    }
}
