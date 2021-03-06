﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YURent.Data;

namespace YURent.Areas.Identity.Data
{
    public class Reservas
    {
        [Key]
        public int Id_reserva { get; set; }
        public Anuncios Anuncio { get; set; }
        public Utilizador Utilizador { get; set; }
        public DateTime Data_inicio { get; set; }
        public DateTime Data_fim { get; set; }
        public double Preco { get; set; }
        public bool Aceite { get; set; }
        public bool Cancelado { get; set; }


    }
}
