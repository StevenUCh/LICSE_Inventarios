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
    public class ENTRADASController : Controller
    {
        private LICSE_InventariosEntities db = new LICSE_InventariosEntities();

        // GET: ENTRADAS
        public async Task<ActionResult> Index()
        {
            if (Session["User"] != null)
            {
                var eNTRADA = db.ENTRADA.Include(e => e.ELEMENTO1).Include(e => e.USUARIO1);
                return View(await eNTRADA.ToListAsync());
            }
            return RedirectToAction("index", "Home");
            
        }

        // GET: ENTRADAS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ENTRADA eNTRADA = await db.ENTRADA.FindAsync(id);
                if (eNTRADA == null)
                {
                    return HttpNotFound();
                }
                return View(eNTRADA);
            }
            return RedirectToAction("index", "Home");
            
        }

        // GET: ENTRADAS/Create
        public ActionResult Create()
        {

            if (Session["User"] != null)
            {
                ViewBag.elemento = new SelectList(db.ELEMENTO, "id_elem", "elem_ref");
                ViewBag.usuario = new SelectList(db.USUARIO, "id_usuario", "usu_nombre");
                return View();
            }
            return RedirectToAction("index", "Home");            
        }

        // POST: ENTRADAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_registro,elemento,cant,fecha,usuario")] ENTRADA eNTRADA)
        {
            if (ModelState.IsValid)
            {
                db.ENTRADA.Add(eNTRADA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.elemento = new SelectList(db.ELEMENTO, "id_elem", "elem_ref", eNTRADA.elemento);
            ViewBag.usuario = new SelectList(db.USUARIO, "id_usuario", "usu_nombre", eNTRADA.usuario);
            return View(eNTRADA);
        }

        // GET: ENTRADAS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ENTRADA eNTRADA = await db.ENTRADA.FindAsync(id);
                if (eNTRADA == null)
                {
                    return HttpNotFound();
                }
                ViewBag.elemento = new SelectList(db.ELEMENTO, "id_elem", "elem_ref", eNTRADA.elemento);
                ViewBag.usuario = new SelectList(db.USUARIO, "id_usuario", "usu_nombre", eNTRADA.usuario);
                return View(eNTRADA);
            }
            return RedirectToAction("index", "Home");            
        }

        // POST: ENTRADAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_registro,elemento,cant,fecha,usuario")] ENTRADA eNTRADA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eNTRADA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.elemento = new SelectList(db.ELEMENTO, "id_elem", "elem_ref", eNTRADA.elemento);
            ViewBag.usuario = new SelectList(db.USUARIO, "id_usuario", "usu_nombre", eNTRADA.usuario);
            return View(eNTRADA);
        }

        // GET: ENTRADAS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {

            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ENTRADA eNTRADA = await db.ENTRADA.FindAsync(id);
                if (eNTRADA == null)
                {
                    return HttpNotFound();
                }
                return View(eNTRADA);
            }
            return RedirectToAction("index", "Home");
            
        }

        // POST: ENTRADAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ENTRADA eNTRADA = await db.ENTRADA.FindAsync(id);
            db.ENTRADA.Remove(eNTRADA);
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
