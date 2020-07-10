using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YURent.Models;

namespace YURent.Models
{
    public class ReservasModel
    {
        [Key]
        public int Id_reserva { get; set; }
        public AnunciosModel Anuncio { get; set; }
        
        [Display(Name = "Data de Inicio")]
        public DateTime Data_inicio { get; set; }
        [Display(Name = "Data de Fim")]
        public DateTime Data_fim { get; set; }
        public float Preco { get; set; }
        public bool Cancelado { get; set; }

        public UtilizadorModel Utilizador { get; set; }

    }
}
