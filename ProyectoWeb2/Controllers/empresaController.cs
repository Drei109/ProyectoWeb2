using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb2.Models;

namespace ProyectoWeb2.Controllers
{
    public class empresaController : Controller
    {
        // GET: empresa
        private empresa empresa = new empresa();
        private estado_empresa estado = new estado_empresa();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(empresa.Listar());
            }
            else
            {
                return View(empresa.buscar(criterio));
            }

        }

        public ActionResult ver(int id)
        {

            return View(empresa.Obtener(id));


        }
        public ActionResult buscar(string criterio)
        {
            return View(
                criterio == null || criterio == "" ? empresa.Listar() : empresa.buscar(criterio)
                );
        }
        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Estado = estado.Listar();
            return View(id == 0 ? new empresa() : empresa.Obtener(id));
        }
        public ActionResult Guardar(empresa empresa)
        {
            ViewBag.Estado = estado.Listar();
            if (ModelState.IsValid)
            {
                empresa.guardar();
                return Redirect("~/empresa");
            }
            else
            {
                return View("~/Views/empresa/Agregar.cshtml", empresa);
            }
        }
        public ActionResult Eliminar(int id = 0)
        {
            empresa.empresa_id = id;
            empresa.eliminar();
            return Redirect("~/empresa");
        }
    }
}