using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameZone.AcessoDados;
using GameZone.Models;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private GameContexto db = new GameContexto();

        // GET: Games
        public ActionResult Index()
        {
            var games = db.Games.Include(g => g.FaixaEtaria).Include(g => g.Genero).Include(g => g.Plataforma).Include(g => g.Publisher);
            return View(games.ToList());
        }

        public PartialViewResult Listar(int pagina = 1, int registros = 5)
        {
            var games = db.Games.Include(g => g.FaixaEtaria).Include(g => g.Genero).Include(g => g.Plataforma).Include(g => g.Publisher);
            var gamesPaginados = games.OrderBy(g => g.Titulo).Skip((pagina -1)* registros).Take(registros);
            //No método Take, estamos pedindo para o Entityframework entregar apenas uma quantidade registros.
            //No método Skip, estamos pedindo para o Entityframework pular uma quantidade registros.
            return PartialView("_Listar", gamesPaginados.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.FaixaEtariaId = new SelectList(db.FaixaEtarias, "FaixaEtariaId", "TipoDeClassificacao");
            ViewBag.GeneroId = new SelectList(db.Generos, "GeneroId", "Nome");
            ViewBag.PlataformaId = new SelectList(db.Plataformas, "PlataformaId", "Nome");
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Nome");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameId,Titulo,AnoEdicao,Valor,GeneroId,PlataformaId,PublisherId,FaixaEtariaId")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FaixaEtariaId = new SelectList(db.FaixaEtarias, "FaixaEtariaId", "TipoDeClassificacao", game.FaixaEtariaId);
            ViewBag.GeneroId = new SelectList(db.Generos, "GeneroId", "Nome", game.GeneroId);
            ViewBag.PlataformaId = new SelectList(db.Plataformas, "PlataformaId", "Nome", game.PlataformaId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Nome", game.PublisherId);
            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.FaixaEtariaId = new SelectList(db.FaixaEtarias, "FaixaEtariaId", "TipoDeClassificacao", game.FaixaEtariaId);
            ViewBag.GeneroId = new SelectList(db.Generos, "GeneroId", "Nome", game.GeneroId);
            ViewBag.PlataformaId = new SelectList(db.Plataformas, "PlataformaId", "Nome", game.PlataformaId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Nome", game.PublisherId);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameId,Titulo,AnoEdicao,Valor,GeneroId,PlataformaId,PublisherId,FaixaEtariaId")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FaixaEtariaId = new SelectList(db.FaixaEtarias, "FaixaEtariaId", "TipoDeClassificacao", game.FaixaEtariaId);
            ViewBag.GeneroId = new SelectList(db.Generos, "GeneroId", "Nome", game.GeneroId);
            ViewBag.PlataformaId = new SelectList(db.Plataformas, "PlataformaId", "Nome", game.PlataformaId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Nome", game.PublisherId);
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
