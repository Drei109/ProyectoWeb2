using System.Data.Entity;
using System.Linq;

namespace ProyectoWeb2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class usuario_tipo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario_tipo()
        {
            usuario = new HashSet<usuario>();
        }

        [Key]
        public int usuario_tipo_id { get; set; }

        [Required]
        [StringLength(100)]
        public string descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario> usuario { get; set; }

        public List<usuario_tipo> Listar()
        {
            var empre = new List<usuario_tipo>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.usuario_tipo.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public usuario_tipo Obtener(int id)
        {
            var empre = new usuario_tipo();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.usuario_tipo.Where(x => x.usuario_tipo_id == id).SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public List<usuario_tipo> buscar(string criterio)
        {
            var empre = new List<usuario_tipo>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.usuario_tipo.Where(x => x.descripcion.Contains(criterio)).ToList();
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
                    if (this.usuario_tipo_id > 0)
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
