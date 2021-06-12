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
    public class TIPO_SEDEController : Controller
    {
        private LICSE_InventariosEntities db = new LICSE_InventariosEntities();

        // GET: TIPO_SEDE
        public async Task<ActionResult> Index()
        {
            if (Session["User"] != null)
            {
                return View(await db.TIPO_SEDE.ToListAsync());
            }
            return RedirectToAction("index", "Home");
            
        }

        // GET: TIPO_SEDE/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TIPO_SEDE tIPO_SEDE = await db.TIPO_SEDE.FindAsync(id);
                if (tIPO_SEDE == null)
                {
                    return HttpNotFound();
                }
                return View(tIPO_SEDE);
            }
            return RedirectToAction("index", "Home");

            
        }

        // GET: TIPO_SEDE/Create
        public ActionResult Create()
        {
            if (Session["User"] != null)
            {                
                return View();
            }
            return RedirectToAction("index", "Home");
        }

        // POST: TIPO_SEDE/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_tipo,nombre")] TIPO_SEDE tIPO_SEDE)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_SEDE.Add(tIPO_SEDE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tIPO_SEDE);
        }

        // GET: TIPO_SEDE/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TIPO_SEDE tIPO_SEDE = await db.TIPO_SEDE.FindAsync(id);
                if (tIPO_SEDE == null)
                {
                    return HttpNotFound();
                }
                return View(tIPO_SEDE);
            }
            return RedirectToAction("index", "Home");            
        }

        // POST: TIPO_SEDE/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_tipo,nombre")] TIPO_SEDE tIPO_SEDE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_SEDE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tIPO_SEDE);
        }

        // GET: TIPO_SEDE/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TIPO_SEDE tIPO_SEDE = await db.TIPO_SEDE.FindAsync(id);
                if (tIPO_SEDE == null)
                {
                    return HttpNotFound();
                }
                return View(tIPO_SEDE);
                }
            return RedirectToAction("index", "Home");

            
        }

        // POST: TIPO_SEDE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TIPO_SEDE tIPO_SEDE = await db.TIPO_SEDE.FindAsync(id);
            db.TIPO_SEDE.Remove(tIPO_SEDE);
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
