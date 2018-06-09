using System.Data.Entity;
using System.Linq;

namespace ProyectoWeb2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pedido_detalle
    {
        [Key]
        public int pedido_detalle_id { get; set; }

        public int pedido_cabecera_id_fk { get; set; }

        public int plato_id_fk { get; set; }

        public int cantidad { get; set; }

        [Column(TypeName = "money")]
        public decimal precio { get; set; }

        public virtual pedido_cabecera pedido_cabecera { get; set; }

        public virtual plato plato { get; set; }

        public List<pedido_detalle> Listar()
        {
            var empre = new List<pedido_detalle>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.pedido_detalle.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public pedido_detalle Obtener(int id)
        {
            var empre = new pedido_detalle();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.pedido_detalle.Where(x => x.pedido_detalle_id == id).SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public List<pedido_detalle> buscar(string criterio)
        {
            var empre = new List<pedido_detalle>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.pedido_detalle.Where(x => x.plato.nombre.Contains(criterio)).ToList();


                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public void guardar()
        {
            try
            {
                using (var db = new RrestauranteModel())
                {
                    if (this.pedido_detalle_id > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public void eliminar()
        {
            try
            {
                using (var db = new RrestauranteModel())
                {

                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}
