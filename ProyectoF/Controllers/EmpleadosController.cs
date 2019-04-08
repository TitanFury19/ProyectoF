using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ProyectoF.Models;

namespace ProyectoF.Controllers
{
    public class EmpleadosController : Controller
    {
        private finalDBCONTEXT db = new finalDBCONTEXT();

        // GET: Empleados
        public ActionResult Index()
        {
            
            var empleados = db.Empleados.Include(e => e.cargo1).Include(e => e.Departamento1);       
            return View(empleados.ToList());
        }
      /*  protected void GrvEntregas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Empleado em = new Empleado();

           if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (em.Estatus == "Inanctivo")
                {
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                }
            }
        }*/

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.Cargo = new SelectList(db.cargoes, "ID", "Cargo1");
            ViewBag.Departamento = new SelectList(db.Departamentoes, "ID", "Nombre");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Codigo_Empleado,Departamento,Nombre,Apellido,Cargo,Salario,Fecha_DE_Ingreso,Telefono,Estatus")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cargo = new SelectList(db.cargoes, "ID", "Cargo1", empleado.Cargo);
            ViewBag.Departamento = new SelectList(db.Departamentoes, "ID", "Nombre", empleado.Departamento);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cargo = new SelectList(db.cargoes, "ID", "Cargo1", empleado.Cargo);
            ViewBag.Departamento = new SelectList(db.Departamentoes, "ID", "Nombre", empleado.Departamento);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Codigo_Empleado,Departamento,Nombre,Apellido,Cargo,Salario,Fecha_DE_Ingreso,Telefono,Estatus")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cargo = new SelectList(db.cargoes, "ID", "Cargo1", empleado.Cargo);
            ViewBag.Departamento = new SelectList(db.Departamentoes, "ID", "Nombre", empleado.Departamento);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleados.Find(id);
            db.Empleados.Remove(empleado);
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
