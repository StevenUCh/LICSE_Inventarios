using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_LICSE.Controllers
{
    public class CloseController : Controller
    {
        // GET: Close
        public ActionResult cerrar_sesion()
        {
            Session["User"] = null;
            return RedirectToAction("index","Home");
        }
    }
}