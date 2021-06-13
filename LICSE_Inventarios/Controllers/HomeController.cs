using LICSE_Inventarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LICSE_Inventarios.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            //try
            //{                
            //    //ViewBag.Error = TempData["Error"].ToString();
            //} 
            //catch { }
            return View();
        }
       
        [HttpPost]
        public ActionResult Login(int username, string pass)
        {
            pass = Encrypt.GetSHA256(pass);
            var home = "";
            
            try
            {
                using (Models.LICSE_InventariosEntities db = new Models.LICSE_InventariosEntities())
                {                    
                    var oUser = (from s in db.USUARIO
                                 join sa in db.ROL on s.rol equals sa.id_rol
                                 where s.id_usuario == username && s.contraseña == pass && s.estado == 1
                                 select new { s.id_usuario, sa.nombre }).FirstOrDefault();                    

                    var rol = oUser.nombre;
                    

                    if (oUser == null)
                    {                                               
                        return View();
                    }
                    else
                    {
                        //Session["User"] = oUser;
                        switch (rol)
                        {
                            case "Administrador":
                                home = "Inicio_Admin";
                                Session["User"] = oUser;
                                break;
                            case "Auxiliar":
                                home = "Inicio_Auxiliar";
                                Session["User"] = oUser;
                                break;
                            default:
                                //TempData["Error"] = "No tiene rol el usuario";
                                break;
                        }
                    }
                }

                return RedirectToAction(home, "home");
            }
            catch
            {
                TempData["Error"] = "Usuario o clave invalida";
                ViewBag.Error = TempData["Error"].ToString();
                return View();
            }

        }
        public ActionResult Inicio_Admin()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            return RedirectToAction("index", "Home");
        }
        public ActionResult Inicio_Auxiliar()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            return RedirectToAction("index", "Home");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}