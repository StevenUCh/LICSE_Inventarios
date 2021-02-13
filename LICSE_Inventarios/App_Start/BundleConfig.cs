using System.Web;
using System.Web.Optimization;

namespace LICSE_Inventarios
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
           

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/vendor/jquery/jquery-3.2.1.min.js",
                        "~/Content/vendor/animsition/js/animsition.min.js",
                        "~/Content/vendor/bootstrap/js/popper.js",
                        "~/Content/vendor/bootstrap/js/bootstrap.min.js",
                        "~/Content/vendor/select2/select2.min.js",
                        "~/Content/vendor/daterangepicker/moment.min.js",
                        "~/Content/vendor/daterangepicker/daterangepicker.js",
                        "~/Content/vendor/countdowntime/countdowntime.js",
                        "~/Content/js/main.js",
                        "~/Content/js/controlador_login.js",
                        "~/Content/js/jquery-2.1.1.js",
                        "~/Content/js/bootstrap.min.js",
                        "~/Content/js/menu.js",
                        "~/Content/js/animated-headline.js",
                        "~/Content/js/isotope.pkgd.min.js",
                        "~/Content/js/custom.js",
                        "~/Content/js/Global.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/js/main.js",
                      "~/Content/js/controlador_login.js",
                      "~/Content/js/jquery-2.1.1.js",
                      "~/Content/js/bootstrap.min.js",
                      "~/Content/js/menu.js",
                      "~/Content/js/animated-headline.js",
                      "~/Content/js/isotope.pkgd.min.js",
                      "~/Content/js/custom.js",
                      "~/Content/js/Global.js",
                      "~/Content/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/ionicons/css/ionicons.min.css",
                      "~/Content/css/style.css"));

            bundles.Add(new StyleBundle("~/Content/ventor").Include(
                      "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/fonts/font-awesome-4.7.0/css/font-awesome.min.css",
                      "~/Content/fonts/Linearicons-Free-v1.0.0/icon-font.min.css",
                      "~/Content/css/util.css",
                      "~/Content/css/main_login.css"));

            bundles.Add(new StyleBundle("~/Content/Login").Include(
                      "~/Content/Login/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/Login/fonts/font-awesome-4.7.0/css/font-awesome.min.css",
                      "~/Content/Login/fonts/Linearicons-Free-v1.0.0/icon-font.min.css",
                      "~/Content/Login/fonts/iconic/css/material-design-iconic-font.min.css",
                      "~/Content/Login/vendor/animate/animate.css",
                      "~/Content/Login/vendor/css-hamburgers/hamburgers.min.css",
                      "~/Content/Login/vendor/animsition/css/animsition.min.css",
                      "~/Content/Login/vendor/select2/select2.min.css",
                      "~/Content/Login/vendor/daterangepicker/daterangepicker.css",
                      "~/Content/Login/css/util.css",
                      "~/Content/Login/css/main.css"));
        }
    }
}
