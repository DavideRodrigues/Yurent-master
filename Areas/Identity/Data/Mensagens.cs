using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YURent.Data;

namespace YURent.Areas.Identity.Data
{
    public class Mensagens
    {
        [Key]
        public int Id_mensagem { get; set; }
        public Utilizador Utilizador { get; set; }
        public Anuncios Anuncio { get; set; }
        public bool Fromseller { get; set; }
        public string Conteudo { get; set; }
        public bool Vista { get; set; }
        public DateTime Data { get; set; }

        public int Id_utilizador { get; set; }

    }
}
