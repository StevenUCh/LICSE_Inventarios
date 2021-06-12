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
    public class MOVIMIENTOSController : Controller
    {
        private LICSE_InventariosEntities db = new LICSE_InventariosEntities();

        // GET: MOVIMIENTOS
        public async Task<ActionResult> Index()
        {
            if (Session["User"] != null)
            {
                return View(await db.M_entrada.ToListAsync());
            }
            return RedirectToAction("index", "Home");
            
        }

        public async Task<ActionResult> M_Salida()
        {
            if (Session["User"] != null)
            {
                return View(await db.M_Salida.ToListAsync());
            }
            return RedirectToAction("index", "Home");
            
        }

        // GET: MOVIMIENTOS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_entrada m_entrada = await db.M_entrada.FindAsync(id);
            if (m_entrada == null)
            {
                return HttpNotFound();
            }
            return View(m_entrada);
        }

        // GET: MOVIMIENTOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MOVIMIENTOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_registro,elem_ref,elem_nom,cant,fecha,usu_nombre")] M_entrada m_entrada)
        {
            if (ModelState.IsValid)
            {
                db.M_entrada.Add(m_entrada);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(m_entrada);
        }

        // GET: MOVIMIENTOS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_entrada m_entrada = await db.M_entrada.FindAsync(id);
            if (m_entrada == null)
            {
                return HttpNotFound();
            }
            return View(m_entrada);
        }

        // POST: MOVIMIENTOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_registro,elem_ref,elem_nom,cant,fecha,usu_nombre")] M_entrada m_entrada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_entrada).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(m_entrada);
        }

        // GET: MOVIMIENTOS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_entrada m_entrada = await db.M_entrada.FindAsync(id);
            if (m_entrada == null)
            {
                return HttpNotFound();
            }
            return View(m_entrada);
        }

        // POST: MOVIMIENTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_entrada m_entrada = await db.M_entrada.FindAsync(id);
            db.M_entrada.Remove(m_entrada);
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
