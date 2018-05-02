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

        public int usuario_id_fk { get; set; }

        public virtual empresa empresa { get; set; }

        public virtual restaurante restaurante { get; set; }

        public virtual usuario usuario { get; set; }
    }
}
