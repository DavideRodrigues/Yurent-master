using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YURent.Areas.Identity.Data
{
    public class Transacoes
    {
        [Key]
        public int Id_transacoes { get; set; }
        public Reservas Reserva { get; set; }
        public DateTime Data { get; set; }

        public int Id_utilizador { get; set; }

    }
}
