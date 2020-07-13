using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YURent.Models;

namespace YURent.ViewModels
{
    public class Painel
    {
        public UtilizadorModel Utilizador { get; set; }
        public VerificacaoModel Verificacao { get; set; }
        public List<ReservasModel> Reservas { get; set; }
    }
}
