using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GameZone.Models;

namespace GameZone.AcessoDados
{
    public class GamesInit : CreateDatabaseIfNotExists<GameContexto>
    {
        protected override void Seed(GameContexto contexto)
        {
            List<Genero> generos = new List<Genero>()
            {
                new Genero() { Nome = "Ação" },
                new Genero() { Nome = "Aventura" },
                new Genero() { Nome = "Estratégia" },
                new Genero() { Nome = "Terror" },
                new Genero() { Nome = "MMORPG " },
                new Genero() { Nome = "Esporte" },
                new Genero() { Nome = "Corrida" },
                new Genero() { Nome = "Fantasia" },
                new Genero() { Nome = "Infantil" },
                new Genero() { Nome = "FPS" },
                new Genero() { Nome = "MMORTS" },
                new Genero() { Nome = "MMOTBS" },
                new Genero() { Nome = "MMOFPS" },
                new Genero() { Nome = "MMOSG" },
                new Genero() { Nome = "MOBA" },
                new Genero() { Nome = "MMO" },
            };

            generos.ForEach(g => contexto.Generos.Add(g));

            List<Plataforma> plataformas = new List<Plataforma>()
            {
                new Plataforma() { Nome = "XBOX-ONE" },
                new Plataforma() { Nome = "XBOX" },
                new Plataforma() { Nome = "PS4" },
                new Plataforma() { Nome = "PS3" },
                new Plataforma() { Nome = "PS2" },
                new Plataforma() { Nome = "Nintento64" },
                new Plataforma() { Nome = "Super Nintedo" },
                new Plataforma() { Nome = "NintendoDS" },
                new Plataforma() { Nome = "Atari" },
                new Plataforma() { Nome = "Megadrive" },
                new Plataforma() { Nome = "Nintendo Switch" },

            };

            plataformas.ForEach((x => contexto.Plataformas.Add(x)));

            List<Publisher> publishers = new List<Publisher>()
            {
                new Publisher() { Nome = "CAPCOM" },
                new Publisher() { Nome= "SEGA" },
                new Publisher() { Nome = "LEGO" },
                new Publisher() { Nome = "Ubsoft" },
                new Publisher() { Nome= "505 Games" },
                new Publisher() { Nome = "LEGO" },
                new Publisher() { Nome = "EA GAMES" },
            };

            publishers.ForEach(p => contexto.Publishers.Add(p));

            List<FaixaEtaria> faixasEtarias = new List<FaixaEtaria>()
            {
                new FaixaEtaria() { TipoDeClassificacao = "Livre" },
                new FaixaEtaria() { TipoDeClassificacao = "+16" },
                new FaixaEtaria() { TipoDeClassificacao = "+18" },
            };
            faixasEtarias.ForEach(f => contexto.FaixaEtarias.Add(f));


            List<Game> games = new List<Game>()
            {
                new Game() {
                    Titulo = "Resident Evil 7 Gold Edition",
                    AnoEdicao = 2018,
                    Valor = 210.91m,
                    Genero = generos.FirstOrDefault(g => g.Nome == "Terror"),
                    Plataforma = plataformas.FirstOrDefault(g => g.Nome == "PS4"),
                    Publisher = publishers.FirstOrDefault(p => p.Nome == "CAPCOM"),
                    FaixaEtaria = faixasEtarias.FirstOrDefault(f => f.TipoDeClassificacao == "+16")
                    },

                    new Game() {
                    Titulo = "Battlefield 1 Revolution Edition",
                    AnoEdicao = 2017,
                    Valor = 142.41m,
                    Genero = generos.FirstOrDefault(g => g.Nome == "FPS"),
                    Plataforma = plataformas.FirstOrDefault(g => g.Nome == "XBOX-ONE"),
                    Publisher = publishers.FirstOrDefault(p => p.Nome == "EA GAMES"),
                    FaixaEtaria = faixasEtarias.FirstOrDefault(f => f.TipoDeClassificacao == "+16")
                }

            };
            games.ForEach(g => contexto.Games.Add(g));
            contexto.SaveChanges();

        }
    }
}