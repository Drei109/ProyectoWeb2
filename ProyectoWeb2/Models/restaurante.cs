namespace ProyectoWeb2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("restaurante")]
    public partial class restaurante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public restaurante()
        {
            empresa_restaurante_usuario = new HashSet<empresa_restaurante_usuario>();
            mesa = new HashSet<mesa>();
            plato = new HashSet<plato>();
            restaurante_tipo = new HashSet<restaurante_tipo>();
        }

        [Key]
        public int restaurante_id { get; set; }

        public int empresa_id_fk { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(100)]
        public string foto { get; set; }

        public virtual empresa empresa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empresa_restaurante_usuario> empresa_restaurante_usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mesa> mesa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<plato> plato { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<restaurante_tipo> restaurante_tipo { get; set; }

        public List<restaurante> Listar()
        {
            var empre = new List<restaurante>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.restaurante.Include("empresa").ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public restaurante Obtener(int id)
        {
            var empre = new restaurante();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.restaurante.Include("empresa").Where(x => x.restaurante_id == id).SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public List<restaurante> buscar(string criterio)
        {
            var empre = new List<restaurante>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.restaurante.Include("empresa").Where(x => x.nombre.Contains(criterio)).ToList();
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
                    if (this.restaurante_id > 0)
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
