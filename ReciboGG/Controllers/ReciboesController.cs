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
    public class ReciboesController : Controller
    {
        private RecibosGGEntities db = new RecibosGGEntities();

        // GET: Reciboes
        public ActionResult Index()
        {
            var reciboes = db.Reciboes.Include(r => r.Alumno).Include(r => r.Pago_Detalle).Include(r => r.Tutor);
            return View(reciboes.ToList());
        }

        // GET: Reciboes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibo recibo = db.Reciboes.Find(id);
            if (recibo == null)
            {
                return HttpNotFound();
            }
            return View(recibo);
        }

        // GET: Reciboes/Create
        public ActionResult Create()
        {
            ViewBag.Id_Alumno = new SelectList(db.Alumnoes, "Id_Alumno", "Nombre");
            ViewBag.Id_Pago_Detalle = new SelectList(db.Pago_Detalle, "Id_Pago_Detalle", "Detalle");
            ViewBag.Id_Tutor = new SelectList(db.Tutors, "Id_Tutor", "Nombre");
            return View();
        }

        // POST: Reciboes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Recibo,Id_Alumno,Id_Tutor,Id_Pago_Detalle,Fecha,Lugar")] Recibo recibo)
        {
            if (ModelState.IsValid)
            {
                db.Reciboes.Add(recibo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Alumno = new SelectList(db.Alumnoes, "Id_Alumno", "Nombre", recibo.Id_Alumno);
            ViewBag.Id_Pago_Detalle = new SelectList(db.Pago_Detalle, "Id_Pago_Detalle", "Detalle", recibo.Id_Pago_Detalle);
            ViewBag.Id_Tutor = new SelectList(db.Tutors, "Id_Tutor", "Nombre", recibo.Id_Tutor);
            return View(recibo);
        }

        // GET: Reciboes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibo recibo = db.Reciboes.Find(id);
            if (recibo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Alumno = new SelectList(db.Alumnoes, "Id_Alumno", "Nombre", recibo.Id_Alumno);
            ViewBag.Id_Pago_Detalle = new SelectList(db.Pago_Detalle, "Id_Pago_Detalle", "Detalle", recibo.Id_Pago_Detalle);
            ViewBag.Id_Tutor = new SelectList(db.Tutors, "Id_Tutor", "Nombre", recibo.Id_Tutor);
            return View(recibo);
        }

        // POST: Reciboes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Recibo,Id_Alumno,Id_Tutor,Id_Pago_Detalle,Fecha,Lugar")] Recibo recibo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recibo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Alumno = new SelectList(db.Alumnoes, "Id_Alumno", "Nombre", recibo.Id_Alumno);
            ViewBag.Id_Pago_Detalle = new SelectList(db.Pago_Detalle, "Id_Pago_Detalle", "Detalle", recibo.Id_Pago_Detalle);
            ViewBag.Id_Tutor = new SelectList(db.Tutors, "Id_Tutor", "Nombre", recibo.Id_Tutor);
            return View(recibo);
        }

        // GET: Reciboes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibo recibo = db.Reciboes.Find(id);
            if (recibo == null)
            {
                return HttpNotFound();
            }
            return View(recibo);
        }

        // POST: Reciboes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Recibo recibo = db.Reciboes.Find(id);
            db.Reciboes.Remove(recibo);
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
