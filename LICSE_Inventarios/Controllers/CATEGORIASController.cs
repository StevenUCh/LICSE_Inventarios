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
    public class CATEGORIASController : Controller
    {
        private LICSE_InventariosEntities db = new LICSE_InventariosEntities();

        // GET: CATEGORIAS
        public async Task<ActionResult> Index()
        {
            if (Session["User"] != null)
            {
                return View(await db.CATEGORIA.ToListAsync());
            }
            return RedirectToAction("index", "Home");
            
        }

        // GET: CATEGORIAS/Details/5
        public async Task<ActionResult> Details(int? id)
        {

            if (Session["User"] != null)
            {
                
                if (id == null)
                {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CATEGORIA cATEGORIA = await db.CATEGORIA.FindAsync(id);
                if (cATEGORIA == null)
                {
                    return HttpNotFound();
                }
                return View(cATEGORIA);
            }
            return RedirectToAction("index", "Home");
        }

        // GET: CATEGORIAS/Create
        public ActionResult Create()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            return RedirectToAction("index", "Home");
        }

        // POST: CATEGORIAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_categoria,nombre")] CATEGORIA cATEGORIA)
        {
            if (ModelState.IsValid)
            {
                db.CATEGORIA.Add(cATEGORIA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cATEGORIA);
        }

        // GET: CATEGORIAS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CATEGORIA cATEGORIA = await db.CATEGORIA.FindAsync(id);
                if (cATEGORIA == null)
                {
                    return HttpNotFound();
                }
                return View(cATEGORIA);
            }
            return RedirectToAction("index", "Home");

            
        }

        // POST: CATEGORIAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_categoria,nombre")] CATEGORIA cATEGORIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATEGORIA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cATEGORIA);
        }

        // GET: CATEGORIAS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (Session["User"] != null)
            {                
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CATEGORIA cATEGORIA = await db.CATEGORIA.FindAsync(id);
                if (cATEGORIA == null)
                {
                    return HttpNotFound();
                }
                return View(cATEGORIA);
            }
            return RedirectToAction("index", "Home");

            
        }

        // POST: CATEGORIAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CATEGORIA cATEGORIA = await db.CATEGORIA.FindAsync(id);
            db.CATEGORIA.Remove(cATEGORIA);
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
