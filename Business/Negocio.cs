using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;

namespace Business
{
    public class Negocio
    {
        #region variablesPrivadas
        private DataAccess _data = new DataAccess();
        private Respuesta _respuesta = new Respuesta();
        #endregion

        /// <summary>
        /// Registra un Host en la BD 
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public Respuesta RegistrarHost(Host host)
        {
           
            var response = _data.RegistrarHotel(host);
            if (response)
            {
                _respuesta.RespuestaBool = response;
                _respuesta.Mensaje = "El Hotel se ha registrado con éxito.";
            }
            else
            {
                _respuesta.RespuestaBool = response;
                _respuesta.Mensaje = "El Hotel no se ha podido registrar";
            }          
           
            return _respuesta;
        }

        /// <summary>
        /// Registra una Habitación en la BD
        /// </summary>
        /// <param name="habitacion"></param>
        /// <returns></returns>
        public Respuesta RegistrarHabitacion(Habitacion habitacion)
        {

            var response = _data.RegistrarHabitacion(habitacion);
            if (response)
            {
                _respuesta.RespuestaBool = response;
                _respuesta.Mensaje = "La habitación se ha registrado con éxito.";
            }
            else
            {
                _respuesta.RespuestaBool = response;
                _respuesta.Mensaje = "La habitación no se ha podido registrar";
            }

            return _respuesta;
        }

        /// <summary>
        /// Lista las habitaciones de los Host
        /// </summary>
        /// <param name="paginas"></param>
        /// <param name="tamanio"></param>
        /// <returns></returns>
        public List<Host> ListarHostsHabitaciones(int paginas, int tamanio)
        {

            var response = _data.ListarHosts(paginas,tamanio);
            var i = 0;
            foreach (var item in response)
            {
                response[i].Habitaciones = _data.ListarHabitaciones(item.Id.ToString());
                i++;
            }
            return response;
        }
    }
}
