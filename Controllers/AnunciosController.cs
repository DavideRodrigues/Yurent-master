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

        [Route("reservar/{id}/{inicio}/{fim}", Name = "reservarRoute")]
        public async Task<ViewResult> Reservar(int id_anuncio, DateTime inicio, DateTime fim)
        {
            var claimsidentity = User.Identity as ClaimsIdentity;
            var utilizador = _context.Utilizador.FirstOrDefault(a => a.Email == User.Identity.Name);
            var anuncio = _context.Anuncios.FirstOrDefault(a => a.Id_anuncio == id_anuncio);

            Reservas novaReserva = new Reservas()
            {
                Anuncio = anuncio,
                Utilizador = utilizador,
                Data_inicio = inicio,
                Data_fim = fim,
                Preco = anuncio.Preco_dia,
                Cancelado = false
            };

            await _context.Reservas.AddAsync(novaReserva);
            await _context.SaveChangesAsync();

            return View();
        }

        public IActionResult AdicionarAnuncio()
        {
            return View();
        }

        #region Adicionar anúncio
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
                        UrlImagem = model.UrlImagem
                    };

                    await _context.Anuncios.AddAsync(novoAnuncio);
                    await _context.SaveChangesAsync();
                }
            }


            return RedirectToAction("MeusAnuncios");
        }
        #endregion

        #region Detalhes Anuncio
        [Route("anuncio/{id}", Name = "anuncioDetailsRoute")]
        public async Task<ViewResult> Anuncio(int id)
        {

            var anuncio = await _context.Anuncios.FindAsync(id);

            if (anuncio != null)
            {
                var anuncioDetails = new AnunciosModel()
                {
                    Id_anuncio = anuncio.Id_anuncio,
                    Título = anuncio.Título,
                    Descricao = anuncio.Descricao,
                    Categoria = anuncio.Categoria,
                    Preco_dia = anuncio.Preco_dia,
                    UrlImagem = anuncio.UrlImagem
                };

                return View(anuncioDetails);
            }
            return View();
        }
        #endregion

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
                    anuncios.Add(new AnunciosModel()
                    {
                        Id_anuncio = anuncio.Id_anuncio,
                        Título = anuncio.Título,
                        Descricao = anuncio.Descricao,
                        Categoria = anuncio.Categoria,
                        Preco_dia = anuncio.Preco_dia,
                        UrlImagem = anuncio.UrlImagem
                    });
                }
            }

            return View(anuncios);
        }


        #region Editar Anúncio


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
                    Id_anuncio = anuncio.Id_anuncio
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

                if (anuncio.UrlImagem != null)
                {
                    anuncios.UrlImagem = anuncio.UrlImagem;
                }
                _context.SaveChanges();
            }

            return RedirectToAction("MeusAnuncios");
        }

        #endregion

        [Route("EliminarAnuncio/{id}", Name = "eliminarRoute")]
        public IActionResult EliminarAnuncio(int id)
        {
            var anuncio = _context.Anuncios.Where(a => a.Id_anuncio == id);

            if (System.IO.File.Exists(anuncio.UrlImagem))
            {
                System.IO.File.Delete(anuncio.UrlImagem);
            }

            _context.Anuncios.Remove(anuncio);
            _context.SaveChanges();

            return RedirectToAction("MeusAnuncios");
        }
    }
}
