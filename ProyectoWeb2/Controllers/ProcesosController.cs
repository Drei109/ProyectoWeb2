using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb2.Helpers;
using ProyectoWeb2.Models;

namespace ProyectoWeb2.Controllers
{
    //[Route("Procesos")]
    [Authorize]
    public class ProcesosController : Controller
    {
        // GET: Procesos
        public ActionResult Pedidos()
        {
            return View();
        }

        [Route("Procesos/Pedidos/Terminar/{id}")]
        public ActionResult TerminarPedido(int id)
        {
            var pedido = new pedido_cabecera();
            pedido.TerminarPedido(id);
            return RedirectToAction("Pedidos");
        }

        [Route("Procesos/Pedidos/Cancelar/{id}")]
        public ActionResult CancelarPedido(int id)
        {
            var pedido = new pedido_cabecera();
            pedido.CancelarPedido(id);
            return RedirectToAction("Pedidos");
        }

        [Route("Procesos/Mesas/")]
        public ActionResult Mesas()
        {
            return View();
        }

        [Route("Procesos/Mesas/GenerarQR/{id}")]
        public ActionResult Mesas(int id)
        {
            var QRHelper = new QRCodeHelper();
            var codeImage = QRHelper.GenerateQRCode(id.ToString(), 120);
            codeImage.Save(Server.MapPath("~/Uploads/mesa" + id + ".png"), ImageFormat.Png);
            return RedirectToAction("Mesas");
        }

        [Route("Procesos/Mesas/Activar/{id}")]
        public ActionResult ActivarMesa(int id)
        {
            var mesa = new mesa();
            mesa.ActivarMesa(id);
            return RedirectToAction("Mesas");
        }

        [Route("Procesos/Mesas/Desactivar/{id}")]
        public ActionResult DesactivarMesa(int id)
        {
            var mesa = new mesa();
            mesa.DesactivarMesa(id);
            return RedirectToAction("Mesas");
        }

    }
}