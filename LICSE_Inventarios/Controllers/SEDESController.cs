using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LICSE_Inventarios.Models;

namespace LICSE_Inventarios.Controllers
{
    public class SEDESController : Controller
    {
        private LICSE_InventariosEntities db = new LICSE_InventariosEntities();

        // GET: SEDES
        public async Task<ActionResult> Index()
        {
            if (Session["User"] != null)
            {
                var sEDE = db.SEDE.Include(s => s.TIPO_SEDE);
                return View(await sEDE.ToListAsync());
            }
            return RedirectToAction("index", "Home");
            
        }

        // GET: SEDES/Details/5
        public async Task<ActionResult> Details(int? id)
        {

            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                SEDE sEDE = await db.SEDE.FindAsync(id);
                if (sEDE == null)
                {
                    return HttpNotFound();
                }
                return View(sEDE);
            }
            return RedirectToAction("index", "Home");

            
        }

        // GET: SEDES/Create
        public ActionResult Create()
        {
            if (Session["User"] != null)
            {
                ViewBag.tipo = new SelectList(db.TIPO_SEDE, "id_tipo", "nombre");
                return View();
            }
            return RedirectToAction("index", "Home");            
        }

        // POST: SEDES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_sede,sede_nombre,sede_direccion,tipo,sede_encargado")] SEDE sEDE)
        {
            if (ModelState.IsValid)
            {
                db.SEDE.Add(sEDE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.tipo = new SelectList(db.TIPO_SEDE, "id_tipo", "nombre", sEDE.tipo);
            return View(sEDE);
        }

        // GET: SEDES/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                SEDE sEDE = await db.SEDE.FindAsync(id);
                if (sEDE == null)
                {
                    return HttpNotFound();
                }
                ViewBag.tipo = new SelectList(db.TIPO_SEDE, "id_tipo", "nombre", sEDE.tipo);
                return View(sEDE);
            }
            return RedirectToAction("index", "Home");
        }

        // POST: SEDES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_sede,sede_nombre,sede_direccion,tipo,sede_encargado")] SEDE sEDE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sEDE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.tipo = new SelectList(db.TIPO_SEDE, "id_tipo", "nombre", sEDE.tipo);
            return View(sEDE);
        }

        // GET: SEDES/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {

            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                SEDE sEDE = await db.SEDE.FindAsync(id);
                if (sEDE == null)
                {
                    return HttpNotFound();
                }
                return View(sEDE);
            }
            return RedirectToAction("index", "Home");
        }

        // POST: SEDES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SEDE sEDE = await db.SEDE.FindAsync(id);
            db.SEDE.Remove(sEDE);
            await db.SaveChangesAsync();
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
