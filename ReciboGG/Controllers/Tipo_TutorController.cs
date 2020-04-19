using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReciboGG.Models.DB;

namespace ReciboGG.Controllers
{
    public class Tipo_TutorController : Controller
    {
        private RecibosGGEntities db = new RecibosGGEntities();

        // GET: Tipo_Tutor
        public ActionResult Index()
        {
            return View(db.Tipo_Tutor.ToList());
        }

        // GET: Tipo_Tutor/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Tutor tipo_Tutor = db.Tipo_Tutor.Find(id);
            if (tipo_Tutor == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Tutor);
        }

        // GET: Tipo_Tutor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Tutor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Tipo_Tutor,Nombre")] Tipo_Tutor tipo_Tutor)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Tutor.Add(tipo_Tutor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Tutor);
        }

        // GET: Tipo_Tutor/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Tutor tipo_Tutor = db.Tipo_Tutor.Find(id);
            if (tipo_Tutor == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Tutor);
        }

        // POST: Tipo_Tutor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Tipo_Tutor,Nombre")] Tipo_Tutor tipo_Tutor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Tutor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Tutor);
        }

        // GET: Tipo_Tutor/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Tutor tipo_Tutor = db.Tipo_Tutor.Find(id);
            if (tipo_Tutor == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Tutor);
        }

        // POST: Tipo_Tutor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Tipo_Tutor tipo_Tutor = db.Tipo_Tutor.Find(id);
            db.Tipo_Tutor.Remove(tipo_Tutor);
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
