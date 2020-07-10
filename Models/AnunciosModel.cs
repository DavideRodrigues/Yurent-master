using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YURent.Models;

namespace YURent.Models
{
    public class AnunciosModel
    {
        [Key]
        public int Id_anuncio { get; set; }
        public UtilizadorModel Utilizador { get; set; }
        public ReservasModel Rerservas { get; set; }

        [Required(ErrorMessage = "Por favor insira um título")]
        public string Título { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Por favor insira uma descrição")]
        public string Descricao { get; set; }

        public string Categoria { get; set; }

        public string Localizacao { get; set; }

        [Display(Name = "Preço por dia")]
        [Required(ErrorMessage = "Por favor insira o preço por dia")]
        public float Preco_dia { get; set; }

        public int Visualizacoes { get; set; }

        [Display(Name = "Por favor escolhe uma imagem para o anúncio")]
        public IFormFile Imagem { get; set; }

        public string UrlImagem { get; set; }

        public bool Ativo { get; set; }

        public DateTime Data_publicacao { get; set; }

    }
}
