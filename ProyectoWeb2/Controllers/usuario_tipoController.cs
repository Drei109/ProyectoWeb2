using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb2.Models;

namespace ProyectoWeb2.Controllers
{
    public class usuario_tipoController : Controller
    {
        // GET: usuario_tipo
        private usuario_tipo usuario = new usuario_tipo();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(usuario.Listar());
            }
            else
            {
                return View(usuario.buscar(criterio));
            }

        }

        public ActionResult ver(int id)
        {

            return View(usuario.Obtener(id));


        }
        public ActionResult buscar(string criterio)
        {
            return View(
                criterio == null || criterio == "" ? usuario.Listar() : usuario.buscar(criterio)
                );
        }
        public ActionResult Agregar(int id = 0)
        {
            return View(id == 0 ? new usuario_tipo() : usuario.Obtener(id));
        }
        public ActionResult Guardar(usuario_tipo empresa)
        {
            if (ModelState.IsValid)
            {
                empresa.guardar();
                return Redirect("~/usuario_tipo");
            }
            else
            {
                return View("~/Views/usuario_tipo/Agregar.cshtml", empresa);
            }
        }
        public ActionResult Eliminar(int id = 0)
        {
            usuario.usuario_tipo_id = id;
            usuario.eliminar();
            return Redirect("~/usuario_tipo");
        }
    }
}