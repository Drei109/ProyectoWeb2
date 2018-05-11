using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb2.Models;

namespace ProyectoWeb2.Controllers
{
    public class pedido_cabeceraController : Controller
    {
        // GET: perdido_cabecera
        private pedido_cabecera pedido = new pedido_cabecera();

        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(pedido.Listar());
            }
            else
            {
                return View(pedido.buscar(criterio));
            }

        }

        public ActionResult ver(int id)
        {

            return View(pedido.Obtener(id));


        }
        public ActionResult buscar(string criterio)
        {
            return View(
                criterio == null || criterio == "" ? pedido.Listar() : pedido.buscar(criterio)
                );
        }
        public ActionResult Agregar(int id = 0)
        {
            return View(id == 0 ? new pedido_cabecera() : pedido.Obtener(id));
        }
        public ActionResult Guardar(pedido_cabecera empresa)
        {
            if (ModelState.IsValid)
            {
                empresa.guardar();
                return Redirect("~/pedido_cabecera");
            }
            else
            {
                return View("~/Views/pedido_cabecera/Agregar.cshtml", empresa);
            }
        }
        public ActionResult Eliminar(int id = 0)
        {
            pedido.pedido_cabecera_id = id;
            pedido.eliminar();
            return Redirect("~/pedido_cabecera");
        }
    }
}