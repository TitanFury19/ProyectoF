using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoF.Models;

namespace ProyectoF.Controllers
{
    public class PermisosController : Controller
    {
        private finalDBCONTEXT db = new finalDBCONTEXT();

        // GET: Permisos
        public ActionResult Index()
        {
            var permisoes = db.Permisoes.Include(p => p.Empleado);
            return View(permisoes.ToList());
        }

        // GET: Permisos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permiso permiso = db.Permisoes.Find(id);
            if (permiso == null)
            {
                return HttpNotFound();
            }
            return View(permiso);
        }

        // GET: Permisos/Create
        public ActionResult Create()
        {
            ViewBag.FK_Empleado = new SelectList(db.Empleados, "ID", "Nombre");
            return View();
        }

        // POST: Permisos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FK_Empleado,Comentario,Fecha_Entrada,Fecha_Salida")] Permiso permiso)
        {
            if (ModelState.IsValid)
            {
                db.Permisoes.Add(permiso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Empleado = new SelectList(db.Empleados, "ID", "Nombre", permiso.FK_Empleado);
            return View(permiso);
        }

        // GET: Permisos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permiso permiso = db.Permisoes.Find(id);
            if (permiso == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Empleado = new SelectList(db.Empleados, "ID", "Nombre", permiso.FK_Empleado);
            return View(permiso);
        }

        // POST: Permisos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FK_Empleado,Comentario,Fecha_Entrada,Fecha_Salida")] Permiso permiso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permiso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Empleado = new SelectList(db.Empleados, "ID", "Nombre", permiso.FK_Empleado);
            return View(permiso);
        }

        // GET: Permisos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permiso permiso = db.Permisoes.Find(id);
            if (permiso == null)
            {
                return HttpNotFound();
            }
            return View(permiso);
        }

        // POST: Permisos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Permiso permiso = db.Permisoes.Find(id);
            db.Permisoes.Remove(permiso);
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
