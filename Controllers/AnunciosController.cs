using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using YURent.Areas.Identity.Data;
using YURent.Data;
using YURent.Models;
using YURent.Repository;
using YURent.ViewModels;
using System.Globalization;

namespace YURent.Controllers
{
    public class AnunciosController : Controller
    {
        private readonly YURentContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AnunciosController(IWebHostEnvironment hostEnvironment, YURentContext context)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        #region Reservar
        [HttpPost]
        public async Task<IActionResult> Reservar([Bind("Id_anuncio, Id_reserva, Utilizador.Id_utilizador, Data_inicio, Data_fim")] ReservasAnuncios reservasAnuncios, string Preco)
        {

            var claimsidentity = User.Identity as ClaimsIdentity;

            if (User.Identity.IsAuthenticated)
            {
                if (!_context.Reservas.Where(a => a.Utilizador.Email == claimsidentity.Name && a.Anuncio.Id_anuncio == reservasAnuncios.Id_anuncio && a.Data_inicio == reservasAnuncios.Data_inicio && a.Data_fim == reservasAnuncios.Data_fim).Any())
                {
                    var claimsIdentity = User.Identity as ClaimsIdentity;
                    var utilizador = _context.Utilizador.FirstOrDefault(a => a.Email == User.Identity.Name);
                    var anuncio = _context.Anuncios.FirstOrDefault(a => a.Id_anuncio == reservasAnuncios.Id_anuncio);

                    

                    ViewBag.mensagem = "";

                    double Total = double.Parse(Preco, CultureInfo.InvariantCulture.NumberFormat);
                    

                    if (reservasAnuncios.Data_fim > reservasAnuncios.Data_inicio)
                    {
                        Reservas novaReserva = new Reservas
                        {
                            Anuncio = anuncio,
                            Utilizador = utilizador,
                            Data_inicio = reservasAnuncios.Data_inicio,
                            Data_fim = reservasAnuncios.Data_fim,
                            Preco = Total,
                            Cancelado = false,
                            Aceite = false
                        };

                        await _context.Reservas.AddAsync(novaReserva);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Anuncio", new { id = reservasAnuncios.Id_anuncio});
                    }
                    else
                    {
                        ViewBag.mensagem = "Data inválida.";
                        return RedirectToAction("Anuncio", new { id = reservasAnuncios.Id_anuncio });
                    }
                }
                else
                {
                    ViewBag.mensagem = "Já tens uma reserva para esta data";
                    return RedirectToAction("Anuncio", new { id = reservasAnuncios.Id_anuncio });
                }
            }
            else
            {
                string url = "../Identity/Account/Login";
                return Redirect(url);
            }

        }
        #endregion

        #region Adicionar anúncio
        public IActionResult AdicionarAnuncio()
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

        
        //Adiciona um anúncio novo à base de dados
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarAnuncio(AnunciosModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Imagem != null)
                {
                    string folder = "DBImages/anuncios/";
                    folder += Guid.NewGuid().ToString() + "_" + model.Imagem.FileName;


                    string serverFolder = Path.Combine(_hostEnvironment.WebRootPath, folder);

                    await model.Imagem.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    model.UrlImagem = "/" + folder;

                    Anuncios novoAnuncio = new Anuncios
                    {
                        Utilizador = _context.Utilizador.FirstOrDefault(a => a.Email == User.Identity.Name),
                        Título = model.Título,
                        Descricao = model.Descricao,
                        Categoria = model.Categoria,
                        Preco_dia = model.Preco_dia,
                        Data_publicacao = DateTime.UtcNow,
                        UrlImagem = model.UrlImagem,
                        Localizacao = model.Localizacao,
                        Ativo = true
                    };

                    await _context.Anuncios.AddAsync(novoAnuncio);
                    await _context.SaveChangesAsync();
                }
            }


            return RedirectToAction("MeusAnuncios");
        }
        #endregion

        #region Detalhes Anuncio

        public IActionResult Anuncio()
        {
            if (User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Index", "Home", new { area = "" });

        }


        [Route("anuncio/{id}", Name = "anuncioDetailsRoute")]
        public async Task<ViewResult> Anuncio(int id)
        {
            var anuncioAtual = _context.Anuncios.Include(p => p.Utilizador).FirstOrDefault(a => a.Id_anuncio == id);

            var anuncios = await _context.Anuncios.Where(a => a.Utilizador == anuncioAtual.Utilizador).ToListAsync();
            var anunciosModel = new List<AnunciosModel>();


            if (anuncioAtual != null && anuncioAtual.Ativo == true)
            {
                foreach (var anuncio in anuncios)
                {
                    if (anuncio.Id_anuncio != id)
                    {
                        anunciosModel.Add(new AnunciosModel()
                        {
                            Título = anuncio.Título,
                            Descricao = anuncio.Descricao,
                            Categoria = anuncio.Categoria,
                            Preco_dia = anuncio.Preco_dia,
                            UrlImagem = anuncio.UrlImagem,
                            Localizacao = anuncio.Localizacao,
                            Ativo = anuncio.Ativo,
                            Data_publicacao = anuncio.Data_publicacao,
                            Id_anuncio = anuncio.Id_anuncio
                        });
                    }

                }

                UtilizadorModel utilizador = new UtilizadorModel()
                {
                    AnunciosModel = anunciosModel,
                    Id_utilizador = anuncioAtual.Utilizador.Id_utilizador,
                    Descricao = anuncioAtual.Utilizador.Descricao,
                    Nome = anuncioAtual.Utilizador.Nome,
                    UrlImagemPerfil = anuncioAtual.Utilizador.UrlImagemPerfil,
                    Email = anuncioAtual.Utilizador.Email
                };

                var DetalhesAnuncio = new ReservasAnuncios()
                {
                    Utilizador = utilizador,
                    Id_anuncio = anuncioAtual.Id_anuncio,
                    Título = anuncioAtual.Título,
                    Descricao = anuncioAtual.Descricao,
                    Categoria = anuncioAtual.Categoria,
                    Preco_dia = anuncioAtual.Preco_dia,
                    Localizacao = anuncioAtual.Localizacao,
                    UrlImagem = anuncioAtual.UrlImagem,
                    Ativo = anuncioAtual.Ativo,
                    Data_inicio = DateTime.Now,
                    Data_fim = DateTime.Now
                };

                return View(DetalhesAnuncio);
            }
            return View();
        }

        #endregion

        #region Meus Anúncios
        public async Task<ViewResult> MeusAnuncios()
        {
            var claimsidentity = User.Identity as ClaimsIdentity;
            var utilizador = _context.Utilizador.FirstOrDefault(a => a.Email == claimsidentity.Name);

            var anuncios = new List<AnunciosModel>();

            var meusanuncios = await _context.Anuncios.Where(a => a.Utilizador == utilizador).ToListAsync();

            if (meusanuncios?.Any() == true)
            {
                foreach (var anuncio in meusanuncios)
                {
                    if (anuncio.Ativo)
                    {
                        anuncios.Add(new AnunciosModel()
                        {
                            Id_anuncio = anuncio.Id_anuncio,
                            Título = anuncio.Título,
                            Descricao = anuncio.Descricao,
                            Categoria = anuncio.Categoria,
                            Preco_dia = anuncio.Preco_dia,
                            UrlImagem = anuncio.UrlImagem,
                            Localizacao = anuncio.Localizacao,
                            Ativo = anuncio.Ativo
                        });
                    }
                }
            }

            return View(anuncios);
        }
        #endregion

        #region Editar Anúncio
        public IActionResult EditarAnuncio()
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

        [Route("EditarAnuncio/{id}", Name = "editarRoute")]
        public IActionResult EditarAnuncio(int id)
        {
            if (_context.Anuncios.Where(a => a.Id_anuncio == id).Any())
            {

                var anuncio = _context.Anuncios.FirstOrDefault(a => a.Id_anuncio == id);

                var newAnuncio = new AnunciosModel()
                {
                    Título = anuncio.Título,
                    Descricao = anuncio.Descricao,
                    Categoria = anuncio.Categoria,
                    Preco_dia = anuncio.Preco_dia,
                    UrlImagem = anuncio.UrlImagem,
                    Id_anuncio = anuncio.Id_anuncio,
                    Localizacao = anuncio.Localizacao
                };

                return View(newAnuncio);

            }
            else
            {
                var model = new AnunciosModel();
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("EditarAnuncio/{id}", Name = "editarRoute")]
        public async Task<IActionResult> EditarAnuncio(AnunciosModel anuncio, int id)
        {
            if (ModelState.IsValid)
            {
                var anuncios = _context.Anuncios.FirstOrDefault(a => a.Id_anuncio == id);

                if (anuncio.Imagem != null)
                {
                    // Adicionar Nova Imagem
                    string folder = "DBImages/anuncios/";
                    folder += Guid.NewGuid().ToString() + "_" + anuncio.Imagem.FileName;

                    string serverFolder = Path.Combine(_hostEnvironment.WebRootPath, folder);

                    await anuncio.Imagem.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    anuncio.UrlImagem = "/" + folder;

                    //Remover Imagem Atual
                    if (System.IO.File.Exists(anuncios.UrlImagem))
                    {
                        System.IO.File.Delete(anuncios.UrlImagem);
                    }
                }

                anuncios.Título = anuncio.Título;
                anuncios.Descricao = anuncio.Descricao;
                anuncios.Categoria = anuncio.Categoria;
                anuncios.Localizacao = anuncio.Localizacao;
                anuncios.Preco_dia = anuncio.Preco_dia;

                if (anuncio.UrlImagem != null)
                {
                    anuncios.UrlImagem = anuncio.UrlImagem;
                }
                _context.SaveChanges();
            }

            return RedirectToAction("MeusAnuncios");
        }

        #endregion

        #region Eliminar anuncios

        //                                         ERRO ERRO AQUI OLHA PARA ESTE ERRO ERRO ERRO ERRO ERRO

        [Route("EliminarAnuncio/{id}", Name = "eliminarRoute")]
        public IActionResult EliminarAnuncio(int id)
        {
            var anuncio = _context.Anuncios.Where(a => a.Id_anuncio == id).FirstOrDefault();

            if (System.IO.File.Exists(anuncio.UrlImagem))
            {
                System.IO.File.Delete(anuncio.UrlImagem);
            }

            anuncio.Ativo = false;

            _context.SaveChanges();

            return RedirectToAction("MeusAnuncios");
        }
        #endregion

        #region Guardados

        [Route("guardados/{id}", Name = "guardarRoute")]
        public async Task<IActionResult> Guardados(int id)
        {
            var claimsidentity = User.Identity as ClaimsIdentity;

            if (User.Identity.IsAuthenticated)
            {
                var anuncio = _context.Anuncios.FirstOrDefault(a => a.Id_anuncio == id);
                var utilizador = _context.Utilizador.FirstOrDefault(a => a.Email == claimsidentity.Name);

                var guardar = new Guardados()
                {
                    Utilizador = utilizador,
                    Anuncios = anuncio
                };

                if (_context.Guardados.Where(a => a.Utilizador == utilizador && a.Anuncios == anuncio).Any())
                {
                    //_context.Guardados.Remove(guardar);
                }
                else
                {
                    await _context.Guardados.AddAsync(guardar);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Guardados", "Perfil");
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }
        #endregion


    }
}
