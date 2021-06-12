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
    public class SOLICITUDESController : Controller
    {
        private LICSE_InventariosEntities db = new LICSE_InventariosEntities();

        // GET: SOLICITUDES
        public async Task<ActionResult> Index()
        {
            if (Session["User"] != null)
            {
                var sOLICITUD = db.SOLICITUD.Include(s => s.SEDE1).Include(s => s.TECNICO1).Include(s => s.USUARIO1);
                return View(await sOLICITUD.ToListAsync());
            }
            return RedirectToAction("index", "Home");            
        }

        // GET: SOLICITUDES/Details/5
        public async Task<ActionResult> Details(int? id)
        {

            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                SOLICITUD sOLICITUD = await db.SOLICITUD.FindAsync(id);
                if (sOLICITUD == null)
                {
                    return HttpNotFound();
                }
                return View(sOLICITUD);
                }
            return RedirectToAction("index", "Home");
        }

        // GET: SOLICITUDES/Create
        public ActionResult Create()
        {
            if (Session["User"] != null)
            {
                ViewBag.sede = new SelectList(db.SEDE, "id_sede", "sede_nombre");
                ViewBag.tecnico = new SelectList(db.TECNICO, "id_tecnico", "tec_nom");
                ViewBag.usuario = new SelectList(db.USUARIO, "id_usuario", "usu_nombre");
                return View();
            }
            return RedirectToAction("index", "Home");            
        }

        // POST: SOLICITUDES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_solicitud,sol_fecha,usuario,fecha_progra,solicitante,sede,tecnico")] SOLICITUD sOLICITUD)
        {
            if (ModelState.IsValid)
            {
                sOLICITUD.sol_fecha = DateTime.Now; 

                db.SOLICITUD.Add(sOLICITUD);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.sede = new SelectList(db.SEDE, "id_sede", "sede_nombre", sOLICITUD.sede);
            ViewBag.tecnico = new SelectList(db.TECNICO, "id_tecnico", "tec_nom", sOLICITUD.tecnico);
            ViewBag.usuario = new SelectList(db.USUARIO, "id_usuario", "usu_nombre", sOLICITUD.usuario);
            return View(sOLICITUD);
        }

        // GET: SOLICITUDES/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                SOLICITUD sOLICITUD = await db.SOLICITUD.FindAsync(id);
                if (sOLICITUD == null)
                {
                    return HttpNotFound();
                }
                ViewBag.sede = new SelectList(db.SEDE, "id_sede", "sede_nombre", sOLICITUD.sede);
                ViewBag.tecnico = new SelectList(db.TECNICO, "id_tecnico", "tec_nom", sOLICITUD.tecnico);
                ViewBag.usuario = new SelectList(db.USUARIO, "id_usuario", "usu_nombre", sOLICITUD.usuario);
                return View(sOLICITUD);
            }
            return RedirectToAction("index", "Home");            
        }

        // POST: SOLICITUDES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_solicitud,sol_fecha,usuario,fecha_progra,solicitante,sede,tecnico")] SOLICITUD sOLICITUD)
        {



            if (ModelState.IsValid)
            {
                db.Entry(sOLICITUD).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.sede = new SelectList(db.SEDE, "id_sede", "sede_nombre", sOLICITUD.sede);
            ViewBag.tecnico = new SelectList(db.TECNICO, "id_tecnico", "tec_nom", sOLICITUD.tecnico);
            ViewBag.usuario = new SelectList(db.USUARIO, "id_usuario", "usu_nombre", sOLICITUD.usuario);
            return View(sOLICITUD);
        }

        // GET: SOLICITUDES/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {

            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                SOLICITUD sOLICITUD = await db.SOLICITUD.FindAsync(id);
                if (sOLICITUD == null)
                {
                    return HttpNotFound();
                }
                return View(sOLICITUD);
            }
            return RedirectToAction("index", "Home");
        }

        // POST: SOLICITUDES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SOLICITUD sOLICITUD = await db.SOLICITUD.FindAsync(id);
            db.SOLICITUD.Remove(sOLICITUD);
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
