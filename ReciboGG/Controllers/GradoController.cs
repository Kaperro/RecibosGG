using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using ReciboGG.Models.DB;

namespace ReciboGG.Controllers
{
    public class GradoController : Controller
    {
        private RecibosGGEntities db = new RecibosGGEntities();

        // GET: Grado
        public ActionResult Index()
        {
            var gradoes = db.Gradoes.Include(g => g.Alumno).Include(g => g.Maestra);
            return View(gradoes.ToList());
        }

        // GET: Grado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado grado = db.Gradoes.Find(id);
            if (grado == null)
            {
                return HttpNotFound();
            }
            return View(grado);
        }

        // GET: Grado/Create
        public ActionResult Create()
        {
            ViewBag.Id_Alumno = new SelectList(db.Alumnoes, "Id_Alumno", "Nombre");
            ViewBag.Id_Maestra = new SelectList(db.Maestras, "Id_Maestra", "Nombre");
            return View();
        }

        // POST: Grado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Grado,Id_Alumno,Id_Maestra,Nombre")] Grado grado)
        {
            if (ModelState.IsValid)
            {
                db.Gradoes.Add(grado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Alumno = new SelectList(db.Alumnoes, "Id_Alumno", "Nombre", grado.Id_Alumno);
            ViewBag.Id_Maestra = new SelectList(db.Maestras, "Id_Maestra", "Nombre", grado.Id_Maestra);
            return View(grado);
        }

        // GET: Grado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado grado = db.Gradoes.Find(id);
            if (grado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Alumno = new SelectList(db.Alumnoes, "Id_Alumno", "Nombre", grado.Id_Alumno);
            ViewBag.Id_Maestra = new SelectList(db.Maestras, "Id_Maestra", "Nombre", grado.Id_Maestra);
            return View(grado);
        }

        // POST: Grado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Grado,Id_Alumno,Id_Maestra,Nombre")] Grado grado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Alumno = new SelectList(db.Alumnoes, "Id_Alumno", "Nombre", grado.Id_Alumno);
            ViewBag.Id_Maestra = new SelectList(db.Maestras, "Id_Maestra", "Nombre", grado.Id_Maestra);
            return View(grado);
        }

        // GET: Grado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado grado = db.Gradoes.Find(id);
            if (grado == null)
            {
                return HttpNotFound();
            }
            return View(grado);
        }

        // POST: Grado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grado grado = db.Gradoes.Find(id);
            db.Gradoes.Remove(grado);
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
