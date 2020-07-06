using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using YURent.Data;

namespace YURent.Controllers
{
    public class HomeController : Controller
    {
        private readonly YURentContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomeController(IWebHostEnvironment hostEnvironment, YURentContext context)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<ViewResult> ResultadoPesquisa(string procuraString)
        {
            var anuncios = new List<AnunciosModel>();

            if (procuraString == null)
            {
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
                            UrlImagem = anuncio.UrlImagem
                        });
                    }
                }
            }
            else
            {
                var anuncios2 = await _context.Anuncios.Where(a => a.Título.Contains(procuraString)).ToListAsync();

                if (anuncios2?.Any() == true)
                {
                    foreach (var anuncio in anuncios2)
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
            }

            return View(anuncios);
        }

        public async Task<ViewResult> PesquisarCategoria(string categoria)
        {
            var anuncios = new List<AnunciosModel>();
            var anuncios2 = await _context.Anuncios.Where(a => a.Categoria == categoria).ToListAsync();

            if (anuncios2?.Any() == true)
            {
                foreach (var anuncio in anuncios2)
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

            return View();
        }

        public IActionResult Perfil()
        {
            return View();
        }


    }
}