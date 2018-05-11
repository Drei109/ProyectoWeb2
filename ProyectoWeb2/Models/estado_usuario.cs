namespace ProyectoWeb2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class estado_usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public estado_usuario()
        {
            usuario = new HashSet<usuario>();
        }

        [Key]
        public int estado_usuario_id { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario> usuario { get; set; }

        public List<estado_usuario> Listar()
        {
            var empre = new List<estado_usuario>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.estado_usuario.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public estado_usuario Obtener(int id)
        {
            var empre = new estado_usuario();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.estado_usuario.Where(x => x.estado_usuario_id == id).SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public List<estado_usuario> buscar(string criterio)
        {
            var empre = new List<estado_usuario>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.estado_usuario.Where(x => x.nombre.Contains(criterio)).ToList();


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
                    if (this.estado_usuario_id > 0)
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
