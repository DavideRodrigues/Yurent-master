using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YURent.Areas.Identity.Data;
using YURent.Data;
using YURent.Models;
using YURent.ViewModels;

namespace YURent.Controllers
{
    public class PainelController : Controller
    {
        private readonly YURentContext _context;

        public PainelController(YURentContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index() // ENTRAR NO PAINEL
        {
            if (User.Identity.IsAuthenticated)
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                var utilizador = _context.Utilizador.FirstOrDefault(a => a.Email == User.Identity.Name);
                var reservas = await _context.Reservas.Include(p => p.Anuncio).Where(a => a.Anuncio.Utilizador == utilizador).ToListAsync();
                var verificacao = _context.Verificacao.FirstOrDefault(a => a.Utilizador == utilizador);

                var utilizadorModel = new UtilizadorModel()
                {
                    Nome = utilizador.Nome,
                    Email = utilizador.Email,
                    Id_utilizador = utilizador.Id_utilizador,
                    UrlImagemPerfil = utilizador.UrlImagemPerfil
                };

                var verificacaoModel = new VerificacaoModel()
                {
                    Id_verificacao = verificacao.Id_verificacao,
                    Telemovel = verificacao.Telemovel,
                    Num_cc = verificacao.Num_cc,
                    Email = verificacao.Email
                };

                var anuncioModel = new AnunciosModel();
                List<ReservasModel> reservasModel = new List<ReservasModel>();

                foreach (var reserva in reservas)
                {
                    var utilizadorReserva = new UtilizadorModel()
                    {
                        Id_utilizador = reserva.Utilizador.Id_utilizador,
                        Nome = reserva.Utilizador.Nome
                    };
                    anuncioModel = new AnunciosModel()
                    {
                        Id_anuncio = reserva.Anuncio.Id_anuncio,
                        Título = reserva.Anuncio.Título,
                        Categoria = reserva.Anuncio.Categoria,
                        Descricao = reserva.Anuncio.Descricao,
                        Preco_dia = reserva.Anuncio.Preco_dia,
                        UrlImagem = reserva.Anuncio.UrlImagem,
                        Ativo = reserva.Anuncio.Ativo,
                        Localizacao = reserva.Anuncio.Localizacao
                    };

                    reservasModel.Add(new ReservasModel()
                    {
                        Id_reserva = reserva.Id_reserva,
                        Utilizador = utilizadorReserva,
                        Anuncio = anuncioModel,
                        Data_inicio = reserva.Data_inicio,
                        Data_fim = reserva.Data_fim,
                        Preco = reserva.Preco,
                        Aceite = reserva.Aceite,
                        Cancelado = reserva.Cancelado
                    });
                }

                Painel painelData = new Painel()
                {
                    Utilizador = utilizadorModel,
                    Reservas = reservasModel,
                    Verificacao = verificacaoModel
                };

                return View(painelData);
            }
            else
            {
                string url = "../Identity/Account/Login";
                return Redirect(url);
            }
        }

        [Route("Painel/Aceitar/{id}", Name = "aceitarRoute")]
        public async Task<IActionResult> Aceitar(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);

            reserva.Aceite = true;
            reserva.Cancelado = false;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Painel", new { area = "" });
        }

        [Route("Painel/Recusar/{id}", Name = "recusarRoute")]
        public async Task<IActionResult> Recusar(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);

            reserva.Aceite = true;
            reserva.Cancelado = true;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Painel", new { area = "" });
        }

    }
}