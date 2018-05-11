namespace ProyectoWeb2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class tipo_restaurante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_restaurante()
        {
            restaurante_tipo = new HashSet<restaurante_tipo>();
        }

        [Key]
        public int tipo_restaurante_id { get; set; }

        [Required]
        [StringLength(100)]
        public string descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<restaurante_tipo> restaurante_tipo { get; set; }

        public List<tipo_restaurante> Listar()
        {
            var empre = new List<tipo_restaurante>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.tipo_restaurante.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public tipo_restaurante Obtener(int id)
        {
            var empre = new tipo_restaurante();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.tipo_restaurante.Where(x => x.tipo_restaurante_id == id).SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public List<tipo_restaurante> buscar(string criterio)
        {
            var empre = new List<tipo_restaurante>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.tipo_restaurante.Where(x => x.descripcion.Contains(criterio)).ToList();


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
                    if (this.tipo_restaurante_id > 0)
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
