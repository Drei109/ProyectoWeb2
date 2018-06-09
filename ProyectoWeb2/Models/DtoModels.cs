using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWeb2.Models
{
    public class PlatosRestauranteDto
    {
        public int plato_id { get; set; }

        public string nombre { get; set; }

        public decimal precio { get; set; }

        public string descripcion { get; set; }

        public string foto { get; set; }

        public string estado { get; set; }

        public int restaurante_id_fk { get; set; }

        public int categoria_plato_id_fk { get; set; }

        public string restaurante_nombre { get; set; }
    }

    public class mesaRestauranteDTO
    {
        public int mesa_id { get; set; }

        public string nombreRestaurante { get; set; }

        public int restaurante_id { get; set; }
        
    }
}