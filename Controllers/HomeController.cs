﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using YURent.Areas.Identity.Data;
using YURent.Data;
using YURent.Models;

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

        #region Criar Utilizador
        public IActionResult CriarUtilizador()
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
                        Data_criacao = DateTime.UtcNow,
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
        public IActionResult CriarUtilizador(UtilizadorModel utilizador)
        {

            var claimsidentity = User.Identity as ClaimsIdentity;

            if (!_context.Utilizador.Where(a => a.Email == claimsidentity.Name).Any())
            {
                var newUtilizador = new Utilizador()
                {
                    Nome = utilizador.Nome,
                    Data_criacao = DateTime.UtcNow,
                    Email = claimsidentity.Name,
                    UrlImagemPerfil = "~/images/imagem_perfil"
                };

                _context.Utilizador.Add(newUtilizador);
            }
            else
            {
                var utiliza = _context.Utilizador.FirstOrDefault(a => a.Email == claimsidentity.Name);

                utiliza.Nome = utiliza.Nome;
            }


            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region Resultado Pesquisa

        public async Task<ViewResult> ResultadoPesquisa(string procuraString, int id)
        {
            var anuncios = new List<AnunciosModel>();

            if (procuraString == null)
            {
                var allanuncios = await _context.Anuncios.ToListAsync();
                if (allanuncios?.Any() == true)
                {
                    foreach (var anuncio in allanuncios)
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
                                UrlImagem = anuncio.UrlImagem
                            });
                        }
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
                        if (anuncio.Ativo)
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
            }

            return View(anuncios);
        }
        #endregion

        #region Pesquisar Categoria
        [Route("Home/PesquisarCategoria/{categoria}", Name = "categoriaRoute")]
        public async Task<ViewResult> PesquisarCategoria(string categoria)
        {
            var anuncios = new List<AnunciosModel>();
            var ListaAnuncios = await _context.Anuncios.Where(a => a.Categoria == categoria).ToListAsync();
            var AllAnuncios = await _context.Anuncios.ToListAsync();

            if (ListaAnuncios?.Any() == true)
            {
                foreach (var anuncio in ListaAnuncios)
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
                            UrlImagem = anuncio.UrlImagem
                        });
                    }
                }
            }

            return View("ResultadoPesquisa", anuncios);
        }
        #endregion
        public IActionResult Perfil()
        {
            return View();
        }

    }
}