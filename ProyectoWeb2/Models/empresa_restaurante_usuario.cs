using System.Data.Entity;
using System.Linq;

namespace ProyectoWeb2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class empresa_restaurante_usuario
    {
        [Key]
        public int restaurante_usuario_id { get; set; }

        public int empresa_id_fk { get; set; }

        public int? resturante_id_fk { get; set; }

        [StringLength(128)]
        public string usuarioASP_fk_Id { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual empresa empresa { get; set; }

        public virtual restaurante restaurante { get; set; }

        public List<empresa_restaurante_usuario> Listar()
        {
            var empre = new List<empresa_restaurante_usuario>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.empresa_restaurante_usuario.Include("empresa").Include("restaurante").Include("usuario").ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public empresa_restaurante_usuario Obtener(int id)
        {
            var empre = new empresa_restaurante_usuario();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.empresa_restaurante_usuario.Include("empresa").Include("restaurante").Include("usuario").Where(x => x.restaurante_usuario_id == id).SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public List<empresa_restaurante_usuario> buscar(string criterio)
        {
            var empre = new List<empresa_restaurante_usuario>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.empresa_restaurante_usuario.Include("empresa").Include("restaurante").Include("usuario").Where(x => x.empresa.nombre.Contains(criterio)).ToList();


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
                    if (this.restaurante_usuario_id > 0)
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
