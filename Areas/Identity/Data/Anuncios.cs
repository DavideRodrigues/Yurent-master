using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YURent.Areas.Identity.Data;
using YURent.Models;

namespace YURent.Areas.Identity.Data

{
    public class Anuncios
    {
        [Key]
        public int Id_anuncio { get; set; }
        public Utilizador Utilizador { get; set; }

        public string Título { get; set; }
        
        public string Descricao { get; set; }
        
        public string Categoria { get; set; }
        
        public float Preco_dia { get; set; }
        
        public int Visualizacoes { get; set; }

        public string UrlImagem { get; set; }

        public bool Ativo { get; set; }
        public DateTime Data_publicacao { get; set; }
    }
}
