using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YURent.Models
{
    public class TransacoesModel
    {
        [Key]
        public int Id_transacoes { get; set; }

        public ReservasModel ReservasModel { get; set; }

        public DateTime Data { get; set; }


    }
}
