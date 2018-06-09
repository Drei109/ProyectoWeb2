using System.Data.Entity;
using System.Linq;

namespace ProyectoWeb2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("empresa")]
    public partial class empresa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public empresa()
        {
            empresa_restaurante_usuario = new HashSet<empresa_restaurante_usuario>();
            restaurante = new HashSet<restaurante>();
        }

        [Key] public int empresa_id { get; set; }

        public int estado_empresa_id_fk { get; set; }

        [Required] [StringLength(100)] public string nombre { get; set; }

        [Column(TypeName = "text")] public string descripcion { get; set; }

        [Required] [StringLength(11)] public string ruc { get; set; }

        public virtual estado_empresa estado_empresa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empresa_restaurante_usuario> empresa_restaurante_usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<restaurante> restaurante { get; set; }

        public List<empresa> Listar()
        {
            var empre = new List<empresa>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.empresa.Include("estado_empresa").ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

            return empre;
        }

        public empresa Obtener(int id)
        {
            var empre = new empresa();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.empresa.Include("estado_empresa").Where(x => x.empresa_id == id).SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

            return empre;
        }

        public List<empresa> buscar(string criterio)
        {
            var empre = new List<empresa>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.empresa.Include("estado_empresa")
                        .Where(x => x.nombre.Contains(criterio) || x.descripcion.Contains(criterio)).ToList();


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
                    if (this.empresa_id > 0)
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
