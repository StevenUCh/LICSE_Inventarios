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
    public class USUARIOSController : Controller
    {
        private LICSE_InventariosEntities db = new LICSE_InventariosEntities();

        // GET: USUARIOS
        public async Task<ActionResult> Index()
        {
            if (Session["User"] != null)
            {
                var uSUARIO = db.USUARIO.Include(u => u.ESTADO_USUARIO).Include(u => u.ROL1);
                return View(await uSUARIO.ToListAsync());
            }
            return RedirectToAction("index", "Home");
            
        }

        // GET: USUARIOS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                USUARIO uSUARIO = await db.USUARIO.FindAsync(id);
                if (uSUARIO == null)
                {
                    return HttpNotFound();
                }
                return View(uSUARIO);
            }
            return RedirectToAction("index", "Home");

            
        }

        // GET: USUARIOS/Create
        public ActionResult Create()
        {
            if (Session["User"] != null)
            {
                ViewBag.estado = new SelectList(db.ESTADO_USUARIO, "id_estado", "nombre");
                ViewBag.rol = new SelectList(db.ROL, "id_rol", "nombre");
                return View();
            }
            return RedirectToAction("index", "Home");
        }

        // POST: USUARIOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "rol,id_usuario,usu_nombre,usu_apellido,usu_telefono,usu_correo,contraseña,estado")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                uSUARIO.contraseña = Encrypt.GetSHA256(uSUARIO.contraseña);
                db.USUARIO.Add(uSUARIO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.estado = new SelectList(db.ESTADO_USUARIO, "id_estado", "nombre", uSUARIO.estado);
            ViewBag.rol = new SelectList(db.ROL, "id_rol", "nombre", uSUARIO.rol);
            return View(uSUARIO);
        }

        // GET: USUARIOS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                USUARIO uSUARIO = await db.USUARIO.FindAsync(id);
                if (uSUARIO == null)
                {
                    return HttpNotFound();
                }
                ViewBag.estado = new SelectList(db.ESTADO_USUARIO, "id_estado", "nombre", uSUARIO.estado);
                ViewBag.rol = new SelectList(db.ROL, "id_rol", "nombre", uSUARIO.rol);
                return View(uSUARIO);
            }
            return RedirectToAction("index", "Home");

            
        }

        // POST: USUARIOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "rol,id_usuario,usu_nombre,usu_apellido,usu_telefono,usu_correo,contraseña,estado")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.estado = new SelectList(db.ESTADO_USUARIO, "id_estado", "nombre", uSUARIO.estado);
            ViewBag.rol = new SelectList(db.ROL, "id_rol", "nombre", uSUARIO.rol);
            return View(uSUARIO);
        }

        // GET: USUARIOS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (Session["User"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                USUARIO uSUARIO = await db.USUARIO.FindAsync(id);
                if (uSUARIO == null)
                {
                    return HttpNotFound();
                }
                return View(uSUARIO);
            }
            return RedirectToAction("index", "Home");

            
        }

        // POST: USUARIOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            USUARIO uSUARIO = await db.USUARIO.FindAsync(id);
            db.USUARIO.Remove(uSUARIO);
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
