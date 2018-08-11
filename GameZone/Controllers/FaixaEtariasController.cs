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
    public class FaixaEtariasController : Controller
    {
        private GameContexto db = new GameContexto();

        // GET: FaixaEtarias
        public ActionResult Index()
        {
            return View(db.FaixaEtarias.ToList());
        }

        // GET: FaixaEtarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FaixaEtaria faixaEtaria = db.FaixaEtarias.Find(id);
            if (faixaEtaria == null)
            {
                return HttpNotFound();
            }
            return View(faixaEtaria);
        }

        // GET: FaixaEtarias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FaixaEtarias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FaixaEtariaId,TipoDeClassificacao")] FaixaEtaria faixaEtaria)
        {
            if (ModelState.IsValid)
            {
                db.FaixaEtarias.Add(faixaEtaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(faixaEtaria);
        }

        // GET: FaixaEtarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FaixaEtaria faixaEtaria = db.FaixaEtarias.Find(id);
            if (faixaEtaria == null)
            {
                return HttpNotFound();
            }
            return View(faixaEtaria);
        }

        // POST: FaixaEtarias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FaixaEtariaId,TipoDeClassificacao")] FaixaEtaria faixaEtaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faixaEtaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faixaEtaria);
        }

        // GET: FaixaEtarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FaixaEtaria faixaEtaria = db.FaixaEtarias.Find(id);
            if (faixaEtaria == null)
            {
                return HttpNotFound();
            }
            return View(faixaEtaria);
        }

        // POST: FaixaEtarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FaixaEtaria faixaEtaria = db.FaixaEtarias.Find(id);
            db.FaixaEtarias.Remove(faixaEtaria);
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
