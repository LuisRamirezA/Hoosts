using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TipoHabitacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool EsActivo { get; set; }
        public ICollection<Habitacion> Habitaciones { get; set; }
    }
}
