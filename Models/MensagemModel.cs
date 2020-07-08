using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YURent.Models;

namespace YURent.Models
{
    public class MensagemModel
    {
        [Key]
        public int Id_mensagem { get; set; }
        [ForeignKey("Id")]


        public int Id_anuncio { get; set; }
        public bool Fromseller { get; set; }
        public string Conteudo { get; set; }
        public bool Vista { get; set; }
        public DateTime Data { get; set; }

        public UtilizadorModel UtilizadorModel { get; set; }

    }
}
