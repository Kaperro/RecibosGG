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
    public class TutorsController : Controller
    {
        private RecibosGGEntities db = new RecibosGGEntities();

        // GET: Tutors
        public ActionResult Index()
        {
            var tutors = db.Tutors.Include(t => t.Tipo_Tutor);
            return View(tutors.ToList());
        }

        // GET: Tutors/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutor tutor = db.Tutors.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            return View(tutor);
        }

        // GET: Tutors/Create
        public ActionResult Create()
        {
            ViewBag.Id_Tipo_Tutor = new SelectList(db.Tipo_Tutor, "Id_Tipo_Tutor", "Nombre");
            return View();
        }

        // POST: Tutors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Tutor,Id_Alumno,Id_Tipo_Tutor,Nombre,Apellidos,DPI,Direccion,Telefono")] Tutor tutor)
        {
            if (ModelState.IsValid)
            {
                db.Tutors.Add(tutor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Tipo_Tutor = new SelectList(db.Tipo_Tutor, "Id_Tipo_Tutor", "Nombre", tutor.Id_Tipo_Tutor);
            return View(tutor);
        }

        // GET: Tutors/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutor tutor = db.Tutors.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Tipo_Tutor = new SelectList(db.Tipo_Tutor, "Id_Tipo_Tutor", "Nombre", tutor.Id_Tipo_Tutor);
            return View(tutor);
        }

        // POST: Tutors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Tutor,Id_Alumno,Id_Tipo_Tutor,Nombre,Apellidos,DPI,Direccion,Telefono")] Tutor tutor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tutor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Tipo_Tutor = new SelectList(db.Tipo_Tutor, "Id_Tipo_Tutor", "Nombre", tutor.Id_Tipo_Tutor);
            return View(tutor);
        }

        // GET: Tutors/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutor tutor = db.Tutors.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            return View(tutor);
        }

        // POST: Tutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Tutor tutor = db.Tutors.Find(id);
            db.Tutors.Remove(tutor);
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
