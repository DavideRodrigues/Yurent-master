using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YURent.Data;

namespace YURent.Areas.Identity.Data
{
    public class Utilizador
    {
        [Key]
        public int Id_utilizador { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlImagemPerfil { get; set; }
        public string Email { get; set; }

        public List<Anuncios> Anuncios { get; set; }

    }
}
