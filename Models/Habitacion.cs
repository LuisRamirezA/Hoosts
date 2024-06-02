using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Habitacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string Codigo { get; set; }
        public bool EsActivo { get; set; }
        public int HostId { get; set; }
        public Host Host { get; set; }
        public int TipoHabitacionId { get; set; }
        public TipoHabitacion TipoHabitacion { get; set; }
    }
}
