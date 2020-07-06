using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public async Task<ViewResult> MeusAnuncios()
        {
            var anuncios = new List<AnunciosModel>();
            var allanuncios = await _context.Anuncios.ToListAsync();
            if (allanuncios?.Any() == true)
            {
                foreach (var anuncio in allanuncios)
                {
                    anuncios.Add(new AnunciosModel()
                    {
                        Id_anuncio = anuncio.Id_anuncio,
                        Título = anuncio.Título,
                        Descricao = anuncio.Descricao,
                        Categoria = anuncio.Categoria,
                        Preco_dia = anuncio.Preco_dia,
                        UrlImagem = anuncio.UrlImagem,
                    });
                }
            }
            return View(anuncios);
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
                        UrlImagem = model.UrlImagem,
                        Visualizacoes = 0
                    };

                    await _context.Anuncios.AddAsync(novoAnuncio);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction("Anuncio", model.Id_anuncio);
        }


        //
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

                var views = new Anuncios
                {
                    Visualizacoes = anuncio.Visualizacoes + 1
                };
                _context.Anuncios.Update(views);
                await _context.SaveChangesAsync();
                return View(anuncioDetails);
            }
            return View();
        }
        #endregion

        #region Meus Anúncios

        //public async Task<ViewResult> MeusAnuncios(int id)
        //{

        //}


        #endregion




    }
}