namespace ProyectoWeb2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class plato_categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public plato_categoria()
        {
            plato = new HashSet<plato>();
        }

        [Key]
        public int plato_categoria_id { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<plato> plato { get; set; }

        public List<plato_categoria> Listar()
        {
            var empre = new List<plato_categoria>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.plato_categoria.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public plato_categoria Obtener(int id)
        {
            var empre = new plato_categoria();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.plato_categoria.Where(x => x.plato_categoria_id == id).SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public List<plato_categoria> buscar(string criterio)
        {
            var empre = new List<plato_categoria>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.plato_categoria.Where(x => x.nombre.Contains(criterio)).ToList();


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
                    if (this.plato_categoria_id > 0)
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
