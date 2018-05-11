namespace ProyectoWeb2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("usuario")]
    public partial class usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario()
        {
            empresa_restaurante_usuario = new HashSet<empresa_restaurante_usuario>();
        }

        [Key]
        public int usuario_id { get; set; }

        public int usuario_tipo_id_fk { get; set; }

        public int estado_usuario_id_fk { get; set; }

        [Column("usuario")]
        [Required]
        [StringLength(100)]
        public string usuario1 { get; set; }

        [Required]
        [StringLength(100)]
        public string usuario_password { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [Required]
        [StringLength(8)]
        public string dni { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empresa_restaurante_usuario> empresa_restaurante_usuario { get; set; }

        public virtual estado_usuario estado_usuario { get; set; }

        public virtual usuario_tipo usuario_tipo { get; set; }

        public List<usuario> Listar()
        {
            var empre = new List<usuario>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.usuario.Include("usuario_tipo").Include("estado_usuario").ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public usuario Obtener(int id)
        {
            var empre = new usuario();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.usuario.Include("usuario_tipo").Include("estado_usuario").Where(x => x.usuario_id == id).SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public List<usuario> buscar(string criterio)
        {
            var empre = new List<usuario>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.usuario.Include("usuario_tipo").Include("estado_usuario").Where(x => x.nombre.Contains(criterio) || x.usuario1.Contains(criterio)).ToList();
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
                    if (this.usuario_id > 0)
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
