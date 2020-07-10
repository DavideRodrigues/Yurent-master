using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YURent.Models;

namespace YURent.ViewModels
{
    public class ReservasAnuncios
    {
        public int Id_anuncio { get; set; }
        public UtilizadorModel Utilizador { get; set; }
        
        public string Título { get; set; }
        public string Descricao { get; set; }

        public string Categoria { get; set; }

        public string Localizacao { get; set; }

        public double Preco_dia { get; set; }

        public int Visualizacoes { get; set; }

        public string UrlImagem { get; set; }

        public bool Ativo { get; set; }

        public double Total { get; set; }

        public DateTime Data_publicacao { get; set; }

        public DateTime Data_inicio { get; set; }
        public DateTime Data_fim { get; set; }

    }
}
