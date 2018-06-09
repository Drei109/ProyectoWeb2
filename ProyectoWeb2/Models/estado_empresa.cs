using System.Data.Entity;
using System.Linq;

namespace ProyectoWeb2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class estado_empresa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public estado_empresa()
        {
            empresa = new HashSet<empresa>();
        }

        [Key]
        public int estado_empresa_id { get; set; }

        [StringLength(100)]
        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empresa> empresa { get; set; }

        public List<estado_empresa> Listar()
        {
            var empre = new List<estado_empresa>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.estado_empresa.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public estado_empresa Obtener(int id)
        {
            var empre = new estado_empresa();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.estado_empresa.Where(x => x.estado_empresa_id == id).SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public List<estado_empresa> buscar(string criterio)
        {
            var empre = new List<estado_empresa>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.estado_empresa.Where(x => x.nombre.Contains(criterio)).ToList();


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
                    if (this.estado_empresa_id > 0)
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
