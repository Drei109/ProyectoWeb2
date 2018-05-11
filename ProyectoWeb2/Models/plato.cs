namespace ProyectoWeb2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("plato")]
    public partial class plato
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public plato()
        {
            pedido_detalle = new HashSet<pedido_detalle>();
        }

        [Key]
        public int plato_id { get; set; }

        public int restaurante_id_fk { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [Column(TypeName = "money")]
        public decimal precio { get; set; }

        public int categoria_plato_id_fk { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string descripcion { get; set; }

        [Required]
        [StringLength(100)]
        public string foto { get; set; }

        [Required]
        [StringLength(100)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pedido_detalle> pedido_detalle { get; set; }

        public virtual plato_categoria plato_categoria { get; set; }

        public virtual restaurante restaurante { get; set; }

        public List<plato> Listar()
        {
            var empre = new List<plato>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.plato.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public plato Obtener(int id)
        {
            var empre = new plato();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.plato.Where(x => x.plato_id == id).SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public List<plato> buscar(string criterio)
        {
            var empre = new List<plato>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.plato.Where(x => x.nombre.Contains(criterio) || x.descripcion.Contains(criterio)).ToList();


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
                    if (this.plato_id > 0)
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
