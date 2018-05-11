using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb2.Models;

namespace ProyectoWeb2.Controllers
{
    public class mesaController : Controller
    {
        // GET: mesa
        private mesa mesa1 = new mesa();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(mesa1.Listar());
            }
            else
            {
                return View(mesa1.buscar(criterio));
            }

        }

        public ActionResult ver(int id)
        {

            return View(mesa1.Obtener(id));


        }
        public ActionResult buscar(string criterio)
        {
            return View(
                criterio == null || criterio == "" ? mesa1.Listar() : mesa1.buscar(criterio)
                );
        }
        public ActionResult Agregar(int id = 0)
        {
            return View(id == 0 ? new mesa() : mesa1.Obtener(id));
        }
        public ActionResult Guardar(mesa empresa)
        {
            if (ModelState.IsValid)
            {
                empresa.guardar();
                return Redirect("~/estado_usuario");
            }
            else
            {
                return View("~/Views/mesa/Agregar.cshtml", empresa);
            }
        }
        public ActionResult Eliminar(int id = 0)
        {
            mesa1.mesa_id = id;
            mesa1.eliminar();
            return Redirect("~/mesa");
        }
    }
}