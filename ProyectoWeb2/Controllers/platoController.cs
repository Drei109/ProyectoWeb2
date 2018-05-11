using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb2.Models;

namespace ProyectoWeb2.Controllers
{
    public class platoController : Controller
    {
        // GET: plato
        private plato plato1 = new plato();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(plato1.Listar());
            }
            else
            {
                return View(plato1.buscar(criterio));
            }

        }

        public ActionResult ver(int id)
        {

            return View(plato1.Obtener(id));


        }
        public ActionResult buscar(string criterio)
        {
            return View(
                criterio == null || criterio == "" ? plato1.Listar() : plato1.buscar(criterio)
                );
        }
        public ActionResult Agregar(int id = 0)
        {
            return View(id == 0 ? new plato() : plato1.Obtener(id));
        }
        public ActionResult Guardar(plato empresa)
        {
            if (ModelState.IsValid)
            {
                empresa.guardar();
                return Redirect("~/plato");
            }
            else
            {
                return View("~/Views/plato/Agregar.cshtml", empresa);
            }
        }
        public ActionResult Eliminar(int id = 0)
        {
            plato1.plato_id = id;
            plato1.eliminar();
            return Redirect("~/plato");
        }
    }
}