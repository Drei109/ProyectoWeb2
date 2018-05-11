using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb2.Models;

namespace ProyectoWeb2.Controllers
{
    public class plato_categoriaController : Controller
    {
        // GET: plato_categoria
        private plato_categoria plato = new plato_categoria();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(plato.Listar());
            }
            else
            {
                return View(plato.buscar(criterio));
            }

        }

        public ActionResult ver(int id)
        {

            return View(plato.Obtener(id));


        }
        public ActionResult buscar(string criterio)
        {
            return View(
                criterio == null || criterio == "" ? plato.Listar() : plato.buscar(criterio)
                );
        }
        public ActionResult Agregar(int id = 0)
        {
            return View(id == 0 ? new plato_categoria() : plato.Obtener(id));
        }
        public ActionResult Guardar(plato_categoria empresa)
        {
            if (ModelState.IsValid)
            {
                empresa.guardar();
                return Redirect("~/plato_categoria");
            }
            else
            {
                return View("~/Views/plato_categoria/Agregar.cshtml", empresa);
            }
        }
        public ActionResult Eliminar(int id = 0)
        {
            plato.plato_categoria_id = id;
            plato.eliminar();
            return Redirect("~/plato_categoria");
        }
    }
}