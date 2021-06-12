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
    public class PROVEEDORESController : Controller
    {
        private LICSE_InventariosEntities db = new LICSE_InventariosEntities();

        // GET: PROVEEDORES
        public async Task<ActionResult> Index()
        {
            if (Session["User"] != null)
            {
                return View(await db.PROVEEDOR.ToListAsync());
            }
            return RedirectToAction("index", "Home");

            
        }

        // GET: PROVEEDORES/Details/5
        public async Task<ActionResult> Details(int? id)
        {

            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PROVEEDOR pROVEEDOR = await db.PROVEEDOR.FindAsync(id);
                if (pROVEEDOR == null)
                {
                    return HttpNotFound();
                }
                return View(pROVEEDOR);
                }
            return RedirectToAction("index", "Home");
            
        }

        // GET: PROVEEDORES/Create
        public ActionResult Create()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            return RedirectToAction("index", "Home");            
        }

        // POST: PROVEEDORES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_proveedor,pro_nombre,pro_telefono,pro_correo")] PROVEEDOR pROVEEDOR)
        {
            if (ModelState.IsValid)
            {
                db.PROVEEDOR.Add(pROVEEDOR);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pROVEEDOR);
        }

        // GET: PROVEEDORES/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PROVEEDOR pROVEEDOR = await db.PROVEEDOR.FindAsync(id);
                if (pROVEEDOR == null)
                {
                    return HttpNotFound();
                }
            return View(pROVEEDOR);
            }
            return RedirectToAction("index", "Home");
        }

        // POST: PROVEEDORES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_proveedor,pro_nombre,pro_telefono,pro_correo")] PROVEEDOR pROVEEDOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROVEEDOR).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pROVEEDOR);
        }

        // GET: PROVEEDORES/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {

            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PROVEEDOR pROVEEDOR = await db.PROVEEDOR.FindAsync(id);
                if (pROVEEDOR == null)
                {
                    return HttpNotFound();
                }
                return View(pROVEEDOR);
                }
                return RedirectToAction("index", "Home");
        }

        // POST: PROVEEDORES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PROVEEDOR pROVEEDOR = await db.PROVEEDOR.FindAsync(id);
            db.PROVEEDOR.Remove(pROVEEDOR);
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
