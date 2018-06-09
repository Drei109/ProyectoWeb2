using System.Data.Entity;
using System.Linq;

namespace ProyectoWeb2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class restaurante_tipo
    {
        [Key]
        public int restaurante_tipo_id { get; set; }

        public int restaurante_id_fk { get; set; }

        public int tipo_restaurante_id_fk { get; set; }

        public virtual restaurante restaurante { get; set; }

        public virtual tipo_restaurante tipo_restaurante { get; set; }

        public List<restaurante_tipo> Listar()
        {
            var empre = new List<restaurante_tipo>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.restaurante_tipo.Include("restaurante").Include("tipo_restaurante").ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public restaurante_tipo Obtener(int id)
        {
            var empre = new restaurante_tipo();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.restaurante_tipo.Include("restaurante").Include("tipo_restaurante").Where(x => x.restaurante_tipo_id == id).SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return empre;
        }
        public List<restaurante_tipo> buscar(string criterio)
        {
            var empre = new List<restaurante_tipo>();
            try
            {
                using (var db = new RrestauranteModel())
                {
                    empre = db.restaurante_tipo.Include("restaurante").Include("tipo_restaurante").Where(x => x.restaurante.nombre.Contains(criterio)).ToList();


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
                    if (this.restaurante_tipo_id > 0)
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
