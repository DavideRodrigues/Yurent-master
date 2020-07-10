using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using YURent.Areas.Identity.Data;
using YURent.Data;
using YURent.Models;
using YURent.Repository;

namespace YURent.Controllers
{
    public class PerfilController : Controller
    {
        private readonly YURentContext _context = null;
        private readonly PerfilRepository _perfilRepository = null;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PerfilController(IWebHostEnvironment hostEnvironment, PerfilRepository perfilRepository, YURentContext context)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
            _perfilRepository = perfilRepository;
        }

        [Route("perfil/{id}", Name = "perfilRoute")]
        public async Task<IActionResult> Index(int id) // ENTRAR NO PAINEL
        {
            var utilizador = await _context.Utilizador.FindAsync(id);
            var anuncios = await _context.Anuncios.Where(a => a.Utilizador == utilizador).ToListAsync();
            var anunciosModel = new List<AnunciosModel>();

            if(utilizador != null)
            {
                foreach(var anuncio in anuncios)
                {
                    anunciosModel.Add(new AnunciosModel()
                    {
                        Id_anuncio = anuncio.Id_anuncio,
                        Título = anuncio.Título,
                        Descricao = anuncio.Descricao,
                        Categoria = anuncio.Categoria,
                        Preco_dia = anuncio.Preco_dia,
                        UrlImagem = anuncio.UrlImagem,
                        Localizacao = anuncio.Localizacao,
                        Ativo = anuncio.Ativo,
                        Data_publicacao = anuncio.Data_publicacao
                    });
                }

                var perfil = new UtilizadorModel()
                { 
                    AnunciosModel = anunciosModel,
                    Nome = utilizador.Nome,
                    Descricao = utilizador.Descricao,
                    UrlImagemPerfil = utilizador.UrlImagemPerfil,
                    Email = utilizador.Email,
                    Data_criacao = utilizador.Data_criacao
                };
                return View(perfil);
            }
            return View();
        }

        #region Editar Foto
        public IActionResult EditarFoto()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarFoto(UtilizadorModel model)
        {
            var claimsidentity = User.Identity as ClaimsIdentity;
            var utilizador = _context.Utilizador.FirstOrDefault(a => a.Email == User.Identity.Name);

            if (ModelState.IsValid)
            {
                if (model.ImagemPerfil != null)
                {
                    string folder = "DBImages/perfil/";
                    folder += Guid.NewGuid().ToString() + "_" + model.ImagemPerfil.FileName;

                    model.UrlImagemPerfil = "/" + folder;

                    string serverFolder = Path.Combine(_hostEnvironment.WebRootPath, folder);
                    await model.ImagemPerfil.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    utilizador.UrlImagemPerfil = model.UrlImagemPerfil;

                    _context.Utilizador.Update(utilizador);

                    await _context.SaveChangesAsync();
                }
            }
            

            if (ViewBag.Title == "Faturacao")
            {
                return RedirectToAction("GerirFaturacao");
            }
            else if (ViewBag.Title == "Verificacao")
            {
                return RedirectToAction("GerirVerificacao");
            }
            return RedirectToAction("GerirConta");
        }
        #endregion

        #region GerirConta
        // Vai buscar os dados da conta e envia-los para o form (se existirem)

        public IActionResult GerirConta()
        {
            var claimsidentity = User.Identity as ClaimsIdentity;

            if (User.Identity.IsAuthenticated)
            {
                if (_context.Utilizador.Where(a => a.Email == claimsidentity.Name).Any())
                {
                    var utilizador = _context.Utilizador.FirstOrDefault(a => a.Email == claimsidentity.Name);

                    var newUtilizador = new UtilizadorModel()
                    {
                        Nome = utilizador.Nome,
                        Email = utilizador.Email,
                        Id_utilizador = utilizador.Id_utilizador,
                        Descricao = utilizador.Descricao,
                        UrlImagemPerfil = utilizador.UrlImagemPerfil
                    };
                    return View(newUtilizador);
                }
                else
                {
                    var model = new UtilizadorModel();
                    return View(model);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        [HttpPost]
        public IActionResult GerirConta(UtilizadorModel utilizador)
        {

            var claimsidentity = User.Identity as ClaimsIdentity;

            if (!_context.Utilizador.Where(a => a.Email == claimsidentity.Name).Any())
            {
                var newUtilizador = new Utilizador()
                {
                    Nome = utilizador.Nome,
                    Descricao = utilizador.Descricao,
                    Email = claimsidentity.Name
                };

                _context.Utilizador.Add(newUtilizador);
                _context.SaveChanges();
            }
            else
            {
                var utiliza = _context.Utilizador.FirstOrDefault(a => a.Email == claimsidentity.Name);

                var ImgUtilizador = new UtilizadorModel()
                {
                    UrlImagemPerfil = utilizador.UrlImagemPerfil
                };


                utiliza.Nome = utilizador.Nome;
                utiliza.Descricao = utilizador.Descricao;

                //_context.SaveChanges();
                return View(ImgUtilizador);
            }

           
            return View();
        }
        #endregion

        #region GerirFaturacao
        // Vai buscar os dados do faturamento e envia-los para o form (se existirem)
        public IActionResult GerirFaturacao()
        {
            var claimsidentity = User.Identity as ClaimsIdentity;
            if (User.Identity.IsAuthenticated)
            {
                if (_context.Faturacao.Where(a => a.Email == claimsidentity.Name).Any())
                {
                    var faturação = _context.Faturacao.Include(p => p.Utilizador).FirstOrDefault(a => a.Email == claimsidentity.Name);

                    UtilizadorModel utilizador = new UtilizadorModel()
                    {
                        Id_utilizador = faturação.Utilizador.Id_utilizador,
                        Nome = faturação.Utilizador.Nome,
                        Descricao = faturação.Utilizador.Descricao,
                        UrlImagemPerfil = faturação.Utilizador.UrlImagemPerfil,
                        Email = faturação.Utilizador.Email
                    };

                    var novaFaturacao = new FaturacaoModel()
                    {
                        Utilizador = utilizador,
                        Nome_completo = faturação.Nome_completo,
                        Morada = faturação.Morada,
                        Codigo_Postal = faturação.Codigo_Postal,
                        Nif = faturação.Nif,
                        Iban = faturação.Iban,
                        Email = faturação.Email,
                        Id_faturacao = faturação.Id_faturacao
                    };

                    return View(novaFaturacao);
                }
                else
                {
                    var model = new FaturacaoModel();

                    return View(model);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            // Enviar o objeto faturação
            
        }

        //Adicionar ou editar faturação
        [HttpPost]
        public IActionResult GerirFaturacao(FaturacaoModel faturacao)
        {

            var claimsidentity = User.Identity as ClaimsIdentity;

            if (!_context.Faturacao.Where(a => a.Email == claimsidentity.Name).Any())
            {
                var newFaturacao = new Faturacao()
                {
                    Utilizador = _context.Utilizador.FirstOrDefault(a => a.Email == User.Identity.Name),
                    Nome_completo = faturacao.Nome_completo,
                    Morada = faturacao.Morada,
                    Codigo_Postal = faturacao.Codigo_Postal,
                    Nif = faturacao.Nif,
                    Iban = faturacao.Iban,
                    Email = claimsidentity.Name
                };

                _context.Faturacao.Add(newFaturacao);
            }
            else
            {
                var fatura = _context.Faturacao.FirstOrDefault(a => a.Email == claimsidentity.Name);

                fatura.Nome_completo = faturacao.Nome_completo;
                fatura.Morada = faturacao.Morada;
                fatura.Codigo_Postal = faturacao.Codigo_Postal;
                fatura.Nif = faturacao.Nif;
                fatura.Iban = faturacao.Iban;
            }


            _context.SaveChanges();
            return View();
        }
        #endregion

        #region GerirVerificacao
        // Vai buscar os dados da verificação e evnia-los para o form (se existirem)
        public IActionResult GerirVerificacao()
        {
            var claimsidentity = User.Identity as ClaimsIdentity;
            // Enviar o objeto verificação
            if (_context.Verificacao.Where(a => a.Email == claimsidentity.Name).Any())
            {
                var vericacao = _context.Verificacao.FirstOrDefault(a => a.Email == claimsidentity.Name);


                var newVerificacao = new VerificacaoModel()
                {
                    Num_cc = vericacao.Num_cc,
                    Telemovel = vericacao.Telemovel

                };

                return View(newVerificacao);
            }
            else
            {
                var model = new VerificacaoModel();

                return View(model);
            }
        }


        //Adicionar ou editar faturação
        [HttpPost]
        public IActionResult GerirVerificacao(VerificacaoModel verificacao)
        {
            var claimsidentity = User.Identity as ClaimsIdentity;

            if (!_context.Verificacao.Where(a => a.Email == claimsidentity.Name).Any())
            {
                var newVerificao = new Verificacao()
                {
                    Num_cc = verificacao.Num_cc,
                    Telemovel = verificacao.Telemovel,
                    Email = claimsidentity.Name
                };

                _context.Verificacao.Add(newVerificao);
            }
            else
            {
                var verifica = _context.Verificacao.FirstOrDefault(a => a.Email == claimsidentity.Name);

                verifica.Num_cc = verificacao.Num_cc;
                verifica.Telemovel = verificacao.Telemovel;
            }


            _context.SaveChanges();
            return View();
        }
        #endregion


        // ERRO
        public async Task<ViewResult> Guardados()
        {
            var claimsidentity = User.Identity as ClaimsIdentity;
            var utilizador = _context.Utilizador.FirstOrDefault(a => a.Email == claimsidentity.Name);

            var GuardadosModel = new List<GuardadosModel>();
            var Guardados = await _context.Guardados.Include(p => p.Anuncios).Where(a => a.Utilizador.Id_utilizador == utilizador.Id_utilizador).ToListAsync();

          if (_context.Guardados.Where(a => a.Utilizador == utilizador).Any())
            {
                foreach (var Guardado in Guardados)
                {
                    var anuncio = new AnunciosModel()
                    {
                        Título = Guardado.Anuncios.Título,
                        Descricao = Guardado.Anuncios.Descricao,
                        Categoria = Guardado.Anuncios.Categoria,
                        Localizacao = Guardado.Anuncios.Localizacao,
                        Preco_dia = Guardado.Anuncios.Preco_dia,
                        UrlImagem = Guardado.Anuncios.UrlImagem,
                        Data_publicacao = Guardado.Anuncios.Data_publicacao
                    };


                    GuardadosModel.Add(new GuardadosModel()
                    {
                        Anuncios = anuncio

                    });
                }
                return View(GuardadosModel);
            }

            return View();
        } 
    }
}
