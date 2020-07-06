using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YURent.Data;

namespace YURent.Models
{
    public class UtilizadorModel
    {
        [Key]
        public int Id_utilizador { get; set; }
        public string Nome { get; set; }
        public IFormFile ImagemPerfil { get; set; }     
        public string UrlImagemPerfil { get; set; }
        public string Email { get; set; }

        public List<AnunciosModel> AnunciosModel { get; set; }
    }
}
