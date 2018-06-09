using System.Data.Entity;
using System.Linq;

namespace ProyectoWeb2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mesa")]
    public partial class mesa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mesa()
        {
            pedido_cabecera = new HashSet<pedido_cabecera>();
        }

        [Key]
        public int mesa_id { get; set; }

        public int restaurante_id_fk { get; set; }

        [Required]
        [StringLength(100)]
        public string estado { get; set; }

        public virtual restaurante restaurante { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pedido_cabecera> pedido_cabecera { get; set; }

        public List<mesa> Listar()
        {
            var empre = new List<mesa>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.mesa.Include(r=>r.restaurante).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public mesa Obtener(int id)
        {
            var empre = new mesa();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.mesa.Where(x => x.mesa_id == id).SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public List<mesa> buscar(string criterio)
        {
            var empre = new List<mesa>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.mesa.Where(x => restaurante.nombre.Contains(criterio)).ToList();


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
                    if (this.mesa_id > 0)
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


        public mesa ActivarMesa(int id)
        {
            var mesa = new mesa();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    mesa = db.mesa.Find(id);
                    mesa.estado = "Activo";
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return mesa;
        }

        public mesa DesactivarMesa(int id)
        {
            var mesa = new mesa();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    mesa = db.mesa.Find(id);
                    mesa.estado = "Inactivo";
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return mesa;
        }
    }
}
