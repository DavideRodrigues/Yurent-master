using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YURent.Models;

namespace YURent.Models
{
    public class FaturacaoModel
    {
        [Key]
        public int Id_faturacao { get; set; }

        public UtilizadorModel Utilizador { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "Por favor insira o seu Nome Completo")]
        public string Nome_completo { get; set; }

        [Required(ErrorMessage = "Por favor insira a sua Morada")]
        public string Morada { get; set; }

        [Display(Name = "Código Postal")]
        [Required(ErrorMessage="Por favor insira o seu código postal")]
        [RegularExpression(@"^\d{4}-\d{3}$", ErrorMessage = "Código Postal Inválido")]
        public string Codigo_Postal { get; set; }

        [Display(Name = "NIF")]
        [Required(ErrorMessage = "Por favor insira o seu NIF")]
        public int Nif { get; set; }

        [Display(Name = "IBAN")]
        [Required(ErrorMessage = "Por favor insira o seu IBAN")]
        public string Iban { get; set; }

        public string Email { get; set; }



    }
}
