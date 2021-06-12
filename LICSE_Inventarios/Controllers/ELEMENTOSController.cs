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
    public class ELEMENTOSController : Controller
    {
        private LICSE_InventariosEntities db = new LICSE_InventariosEntities();

        // GET: ELEMENTOS
        public async Task<ActionResult> Index()
        {
            if (Session["User"] != null)
            {
                var eLEMENTO = db.ELEMENTO.Include(e => e.CATEGORIA1).Include(e => e.PROVEEDOR1);
                return View(await eLEMENTO.ToListAsync());
            }
            return RedirectToAction("index", "Home");
            
        }

        // GET: ELEMENTOS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ELEMENTO eLEMENTO = await db.ELEMENTO.FindAsync(id);
                if (eLEMENTO == null)
                {
                    return HttpNotFound();
                }
                return View(eLEMENTO);
            }
            return RedirectToAction("index", "Home");            
        }

        // GET: ELEMENTOS/Create
        public ActionResult Create()
        {
            if (Session["User"] != null)
            {
                ViewBag.categoria = new SelectList(db.CATEGORIA, "id_categoria", "nombre");
                ViewBag.Proveedor = new SelectList(db.PROVEEDOR, "id_proveedor", "pro_nombre");
                return View();
            }
            return RedirectToAction("index", "Home");
            
        }

        // POST: ELEMENTOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_elem,elem_ref,elem_nom,categoria,Proveedor")] ELEMENTO eLEMENTO)
        {
            if (ModelState.IsValid)
            {
                db.ELEMENTO.Add(eLEMENTO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.categoria = new SelectList(db.CATEGORIA, "id_categoria", "nombre", eLEMENTO.categoria);
            ViewBag.Proveedor = new SelectList(db.PROVEEDOR, "id_proveedor", "pro_nombre", eLEMENTO.Proveedor);
            return View(eLEMENTO);
        }

        // GET: ELEMENTOS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ELEMENTO eLEMENTO = await db.ELEMENTO.FindAsync(id);
                if (eLEMENTO == null)
                {
                    return HttpNotFound();
                }
                ViewBag.categoria = new SelectList(db.CATEGORIA, "id_categoria", "nombre", eLEMENTO.categoria);
                ViewBag.Proveedor = new SelectList(db.PROVEEDOR, "id_proveedor", "pro_nombre", eLEMENTO.Proveedor);
                return View(eLEMENTO);
            }
            return RedirectToAction("index", "Home");
        }

        // POST: ELEMENTOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_elem,elem_ref,elem_nom,categoria,Proveedor")] ELEMENTO eLEMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eLEMENTO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.categoria = new SelectList(db.CATEGORIA, "id_categoria", "nombre", eLEMENTO.categoria);
            ViewBag.Proveedor = new SelectList(db.PROVEEDOR, "id_proveedor", "pro_nombre", eLEMENTO.Proveedor);
            return View(eLEMENTO);
        }

        // GET: ELEMENTOS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {

            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ELEMENTO eLEMENTO = await db.ELEMENTO.FindAsync(id);
                if (eLEMENTO == null)
                {
                    return HttpNotFound();
                }
            return View(eLEMENTO);
            }
            return RedirectToAction("index", "Home");
        }

        // POST: ELEMENTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ELEMENTO eLEMENTO = await db.ELEMENTO.FindAsync(id);
            db.ELEMENTO.Remove(eLEMENTO);
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
