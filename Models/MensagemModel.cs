using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YURent.Data
{
    public class MensagemModel
    {
        [Key]
        public int Id_mensagem { get; set; }
        [ForeignKey("Id")]
        public int Id { get; set; }
        [ForeignKey("Id_anuncio")]
        public int Id_anuncio { get; set; }
        public bool Fromseller { get; set; }
        public string Conteudo { get; set; }
        public bool Vista { get; set; }
        public DateTime Data { get; set; }

        public int Id_utilizador { get; set; }

    }
}
