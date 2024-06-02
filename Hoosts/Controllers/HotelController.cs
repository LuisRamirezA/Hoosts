using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using Business;

namespace Hoosts.Controllers
{
    public class HotelController : Controller
    {
        private Negocio _business = new Negocio();
        private Respuesta respuesta = new Respuesta();
        // GET: Hotel
        [HttpGet]
        public string Get()
        {
            try
            {
                //var response = _negocio.GetSaldo(Tarjeta, Nip);
                return "Bienvenido al sistema de reservación" ;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        /// <summary>
        /// Api para registrar  un Host
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public ActionResult RegistrarHotel(Host host)
        {

            respuesta = _business.RegistrarHost(host);
            return Json(respuesta);
        }

        [HttpPost]
        public ActionResult RegistrarHabitacion(Habitacion habitacion)
        {

            respuesta = _business.RegistrarHabitacion(habitacion);
            return Json(respuesta);
        }


        [HttpPost]
        public ActionResult ListarHosts(int numPagina, int tamanio)
        {

            return Json(_business.ListarHostsHabitaciones(numPagina, tamanio));
        }






    }
}
