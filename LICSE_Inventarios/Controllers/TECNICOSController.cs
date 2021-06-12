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
    public class TECNICOSController : Controller
    {
        private LICSE_InventariosEntities db = new LICSE_InventariosEntities();

        // GET: TECNICOS
        public async Task<ActionResult> Index()
        {
            if (Session["User"] != null)
            {
                return View(await db.TECNICO.ToListAsync());
            }
            return RedirectToAction("index", "Home");            
        }

        // GET: TECNICOS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TECNICO tECNICO = await db.TECNICO.FindAsync(id);
                if (tECNICO == null)
                {
                    return HttpNotFound();
                }
                return View(tECNICO);
            }
            return RedirectToAction("index", "Home");
        }

        // GET: TECNICOS/Create
        public ActionResult Create()
        {
            if (Session["User"] != null)
            {                
                return View();
            }
            return RedirectToAction("index", "Home");
        }

        // POST: TECNICOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_tecnico,tec_nom,tec_tel")] TECNICO tECNICO)
        {
            if (ModelState.IsValid)
            {
                db.TECNICO.Add(tECNICO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tECNICO);
        }

        // GET: TECNICOS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TECNICO tECNICO = await db.TECNICO.FindAsync(id);
                if (tECNICO == null)
                {
                    return HttpNotFound();
                }
                return View(tECNICO);
            }
            return RedirectToAction("index", "Home");
        }

        // POST: TECNICOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_tecnico,tec_nom,tec_tel")] TECNICO tECNICO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tECNICO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tECNICO);
        }

        // GET: TECNICOS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {

            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TECNICO tECNICO = await db.TECNICO.FindAsync(id);
                if (tECNICO == null)
                {
                    return HttpNotFound();
                }
                return View(tECNICO);
            }
            return RedirectToAction("index", "Home");            
        }

        // POST: TECNICOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TECNICO tECNICO = await db.TECNICO.FindAsync(id);
            db.TECNICO.Remove(tECNICO);
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
