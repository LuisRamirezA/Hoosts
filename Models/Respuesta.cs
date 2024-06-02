using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Respuesta
    {
        public int CodigoRespuesta { get; set; }
        public string Mensaje { get; set; }
        public int RespuestaInt { get; set; }
        public decimal RespuestaDecimal { get; set; }
        public bool RespuestaBool { get; set; }
       
    }
}
