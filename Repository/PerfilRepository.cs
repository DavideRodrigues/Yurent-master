using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YURent.Areas.Identity.Data;
using YURent.Data;
using YURent.Models;

namespace YURent.Repository
{
    public class PerfilRepository
    {
        private readonly YURentContext _context = null;

        public PerfilRepository(YURentContext context)
        {
            _context = context;
        }



        #region Conta
        #endregion

        #region Faturação

        #endregion

        #region Verificação

            public int EditarVerificacao(VerificacaoModel model)
        {
            var newVerificao = new Verificacao()
            {
                Num_cc = model.Num_cc,
                Telemovel = model.Telemovel
            };

            _context.Verificacao.Add(newVerificao);
            _context.SaveChanges();

            return newVerificao.Id_verificacao;
        }

        #endregion

    }
}
