using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb2.Models;

namespace ProyectoWeb2.Controllers
{
    public class tipo_restauranteController : Controller
    {
        // GET: tipo_restaurante
        private tipo_restaurante restaurante = new tipo_restaurante();

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
            return View(id == 0 ? new tipo_restaurante() : restaurante.Obtener(id));
        }
        public ActionResult Guardar(tipo_restaurante empresa)
        {
            if (ModelState.IsValid)
            {
                empresa.guardar();
                return Redirect("~/tipo_restaurante");
            }
            else
            {
                return View("~/Views/tipo_restaurante/Agregar.cshtml", empresa);
            }
        }
        public ActionResult Eliminar(int id = 0)
        {
            restaurante.tipo_restaurante_id = id;
            restaurante.eliminar();
            return Redirect("~/tipo_restaurante");
        }
    }
}