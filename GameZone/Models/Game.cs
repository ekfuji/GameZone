using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameZone.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Titulo { get; set; }
        public int AnoEdicao { get; set; }
        public decimal Valor { get; set; }

        public Genero Genero { get; set; }
        public int GeneroId { get; set; }

        public Plataforma Plataforma { get; set; }
        public int PlataformaId { get; set; }

        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }

        public FaixaEtaria FaixaEtaria { get; set; }
        public int FaixaEtariaId { get; set; }
    }
}