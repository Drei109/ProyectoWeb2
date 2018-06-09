using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ProyectoWeb2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pedido_cabecera
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pedido_cabecera()
        {
            pedido_detalle = new HashSet<pedido_detalle>();
        }

        [Key]
        public int pedido_cabecera_id { get; set; }

        public int mesa_id_fk { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }

        [Column(TypeName = "money")]
        public decimal precio_final { get; set; }

        public string estado { get; set; }

        public virtual mesa mesa { get; set; }

        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pedido_detalle> pedido_detalle { get; set; }

        public List<pedido_cabecera> Listar()
        {
            var empre = new List<pedido_cabecera>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.pedido_cabecera.Include(x => x.pedido_detalle.Select(y=>y.plato)).OrderByDescending(z=>z.fecha).ThenBy(a => a.estado).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public pedido_cabecera Obtener(int id)
        {
            var empre = new pedido_cabecera();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.pedido_cabecera.Where(x => x.pedido_cabecera_id == id).SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public List<pedido_cabecera> buscar(string criterio)
        {
            var empre = new List<pedido_cabecera>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.pedido_cabecera.Where(x => x.mesa.restaurante.nombre.Contains(criterio)).ToList();
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
                    if (this.pedido_cabecera_id > 0)
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

        
        public pedido_cabecera TerminarPedido(int id)
        {
            var pedido = new pedido_cabecera();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    pedido = db.pedido_cabecera.Find(id);
                    pedido.estado = "Inactivo";
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return pedido;
        }

        public pedido_cabecera CancelarPedido(int id)
        {
            var pedido = new pedido_cabecera();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    pedido = db.pedido_cabecera.Find(id);
                    pedido.estado = "Cancelado";
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return pedido;
        }
    }
}
