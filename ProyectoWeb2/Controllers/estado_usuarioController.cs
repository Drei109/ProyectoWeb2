using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoWeb2.Models;
using System.Web.Mvc;

namespace ProyectoWeb2.Controllers
{
    public class estado_usuarioController : Controller
    {
        // GET: estado_usuario
        private estado_usuario usuario = new estado_usuario();

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
            return View(id == 0 ? new estado_usuario() : usuario.Obtener(id));
        }
        public ActionResult Guardar(estado_usuario empresa)
        {
            if (ModelState.IsValid)
            {
                empresa.guardar();
                return Redirect("~/estado_usuario");
            }
            else
            {
                return View("~/Views/estado_usuario/Agregar.cshtml", empresa);
            }
        }
        public ActionResult Eliminar(int id = 0)
        {
            usuario.estado_usuario_id = id;
            usuario.eliminar();
            return Redirect("~/estado_usuario");
        }
    }
}