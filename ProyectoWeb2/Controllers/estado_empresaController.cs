using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb2.Models;

namespace ProyectoWeb2.Controllers
{
    public class estado_empresaController : Controller
    {
        // GET: estado_empresa
        private estado_empresa empresa = new estado_empresa();

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
            return View(id == 0 ? new estado_empresa() : empresa.Obtener(id));
        }
        public ActionResult Guardar(estado_empresa empresa)
        {
            if (ModelState.IsValid)
            {
                empresa.guardar();
                return Redirect("~/estado_empresa");
            }
            else
            {
                return View("~/Views/estado_empresa/Agregar.cshtml", empresa);
            }
        }
        public ActionResult Eliminar(int id = 0)
        {
            empresa.estado_empresa_id = id;
            empresa.eliminar();
            return Redirect("~/estado_empresa");
        }
    }
}