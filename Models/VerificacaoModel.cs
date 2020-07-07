using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YURent.Models;

namespace YURent.Data
{
    public class VerificacaoModel
    {
        [Key]
        public int Id_verificacao { get; set; }
        

        [Display(Name = "Telemóvel")]
        [Required(ErrorMessage = "Por favor insira o seu numero de telemóvel.")]
        [StringLength(9, ErrorMessage = "Numero Inválido.")]
        public string Telemovel { get; set; }

        [Display(Name = "Número de Cartão de Cidadão.")]
        [Required(ErrorMessage = "Por favor insira o seu numero de cartão de cidadão.")]
        [StringLength(12, ErrorMessage = "Numero de cartão de cidadão inválido.")]
        public string Num_cc { get; set; }

        public string Email { get; set; }

        public UtilizadorModel utilizador { get; set; }
    }
}

