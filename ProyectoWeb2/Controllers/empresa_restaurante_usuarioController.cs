using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb2.Models;

namespace ProyectoWeb2.Controllers
{
    public class empresa_restaurante_usuarioController : Controller
    {
        // GET: empresa_restaurante_usuario       
        private empresa_restaurante_usuario empresa = new empresa_restaurante_usuario();
        private empresa empresa1 = new empresa();
        private restaurante restaurante = new restaurante();
        private usuario usuario = new usuario();

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
            ViewBag.Empresa = empresa1.Listar();
            ViewBag.Restaurante = restaurante.Listar();
            ViewBag.Usuario = usuario.Listar();
            return View(id == 0 ? new empresa_restaurante_usuario() : empresa.Obtener(id));
        }
        public ActionResult Guardar(empresa_restaurante_usuario empresa)
        {
            ViewBag.Empresa = empresa.Listar();
            ViewBag.Restaurante = empresa.Listar();
            ViewBag.Usuario = usuario.Listar();
            if (ModelState.IsValid)
            {
                empresa.guardar();
                return Redirect("~/empresa_restaurante_usuario");
            }
            else
            {
                return View("~/Views/empresa_restaurante_usuario/Agregar.cshtml", empresa);
            }
        }
        public ActionResult Eliminar(int id = 0)
        {
            empresa.restaurante_usuario_id = id;
            empresa.eliminar();
            return Redirect("~/empresa_restaurante_usuario");
        }
    }    
}