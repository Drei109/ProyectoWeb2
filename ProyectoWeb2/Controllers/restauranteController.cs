using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb2.Models;

namespace ProyectoWeb2.Controllers
{
    public class restauranteController : Controller
    {
        // GET: restaurante
        private restaurante restaurante1 = new restaurante();
        private empresa empresa = new empresa();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(restaurante1.Listar());
            }
            else
            {
                return View(restaurante1.buscar(criterio));
            }

        }

        public ActionResult ver(int id)
        {

            return View(restaurante1.Obtener(id));


        }
        public ActionResult buscar(string criterio)
        {
            return View(
                criterio == null || criterio == "" ? restaurante1.Listar() : restaurante1.buscar(criterio)
                );
        }
        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Empresa = empresa.Listar();
            return View(id == 0 ? new restaurante() : restaurante1.Obtener(id));
        }
        public ActionResult Guardar(restaurante empresa)
        {
            ViewBag.Empresa = empresa.Listar();
            if (ModelState.IsValid)
            {
                empresa.guardar();
                return Redirect("~/restaurante");
            }
            else
            {
                return View("~/Views/restaurante/Agregar.cshtml", empresa);
            }
        }
        public ActionResult Eliminar(int id = 0)
        {
            restaurante1.restaurante_id = id;
            restaurante1.eliminar();
            return Redirect("~/restaurante");
        }
    }
}