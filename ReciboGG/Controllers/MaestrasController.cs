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
    public class MaestrasController : Controller
    {
        private RecibosGGEntities db = new RecibosGGEntities();

        // GET: Maestras
        public ActionResult Index()
        {
            return View(db.Maestras.ToList());
        }

        // GET: Maestras/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maestra maestra = db.Maestras.Find(id);
            if (maestra == null)
            {
                return HttpNotFound();
            }
            return View(maestra);
        }

        // GET: Maestras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maestras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Maestra,Nombre,Apellido,DPI,Direccion,Telefono")] Maestra maestra)
        {
            if (ModelState.IsValid)
            {
                db.Maestras.Add(maestra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maestra);
        }

        // GET: Maestras/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maestra maestra = db.Maestras.Find(id);
            if (maestra == null)
            {
                return HttpNotFound();
            }
            return View(maestra);
        }

        // POST: Maestras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Maestra,Nombre,Apellido,DPI,Direccion,Telefono")] Maestra maestra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maestra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maestra);
        }

        // GET: Maestras/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maestra maestra = db.Maestras.Find(id);
            if (maestra == null)
            {
                return HttpNotFound();
            }
            return View(maestra);
        }

        // POST: Maestras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Maestra maestra = db.Maestras.Find(id);
            db.Maestras.Remove(maestra);
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
