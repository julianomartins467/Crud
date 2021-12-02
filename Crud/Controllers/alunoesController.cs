using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Crud.Models;

namespace Crud.Controllers
{
    public class alunoesController : Controller
    {
        private contexto db = new contexto();

        // GET: alunoes
        public ActionResult Index()
        {
            return View(db.Alunos.ToList());
        }

        // GET: alunoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: alunoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: alunoes/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,Nome,CPF")] aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Alunos.Add(aluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        // GET: alunoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: alunoes/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,Nome,CPF")] aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        // GET: alunoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: alunoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            aluno aluno = db.Alunos.Find(id);
            db.Alunos.Remove(aluno);
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
