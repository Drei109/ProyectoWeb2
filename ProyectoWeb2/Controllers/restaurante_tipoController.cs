using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb2.Models;

namespace ProyectoWeb2.Controllers
{
    public class restaurante_tipoController : Controller
    {
        // GET: restaurante_tipo
        private restaurante_tipo restaurante = new restaurante_tipo();
        private tipo_restaurante tipo = new tipo_restaurante();
        private restaurante restaurante1 = new restaurante();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(restaurante.Listar());
            }
            else
            {
                return View(restaurante.buscar(criterio));
            }

        }

        public ActionResult ver(int id)
        {

            return View(restaurante.Obtener(id));


        }
        public ActionResult buscar(string criterio)
        {
            return View(
                criterio == null || criterio == "" ? restaurante.Listar() : restaurante.buscar(criterio)
                );
        }
        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Tipo = tipo.Listar();
            ViewBag.Restaurante = restaurante1.Listar();
            return View(id == 0 ? new restaurante_tipo() : restaurante.Obtener(id));
        }
        public ActionResult Guardar(restaurante_tipo empresa)
        {
            if (ModelState.IsValid)
            {
                empresa.guardar();
                return Redirect("~/restaurante_tipo");
            }
            else
            {
                return View("~/Views/restaurante_tipo/Agregar.cshtml", empresa);
            }
        }
        public ActionResult Eliminar(int id = 0)
        {
            restaurante.restaurante_tipo_id = id;
            restaurante.eliminar();
            return Redirect("~/restaurante_tipo");
        }
    }
}