using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb2.Models;

namespace ProyectoWeb2.Controllers
{
    public class usuarioController : Controller
    {
        // GET: usuario
        private usuario usuario1 = new usuario();
        private usuario_tipo tipo = new usuario_tipo();
        private estado_usuario estado = new estado_usuario();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(usuario1.Listar());
            }
            else
            {
                return View(usuario1.buscar(criterio));
            }

        }

        public ActionResult ver(int id)
        {

            return View(usuario1.Obtener(id));


        }
        public ActionResult buscar(string criterio)
        {
            return View(
                criterio == null || criterio == "" ? usuario1.Listar() : usuario1.buscar(criterio)
                );
        }
        public ActionResult Agregar(int id = 0)
        {
            ViewBag.Tipo = tipo.Listar();
            ViewBag.Estado = estado.Listar();
            return View(id == 0 ? new usuario() : usuario1.Obtener(id));
        }
        public ActionResult Guardar(usuario empresa)
        {
            ViewBag.Tipo = tipo.Listar();
            ViewBag.Estado = estado.Listar();
            if (ModelState.IsValid)
            {
                empresa.guardar();
                return Redirect("~/usuario");
            }
            else
            {
                return View("~/Views/usuario/Agregar.cshtml", empresa);
            }
        }
        public ActionResult Eliminar(int id = 0)
        {
            usuario1.usuario_id = id;
            usuario1.eliminar();
            return Redirect("~/usuario");
        }
    }
}