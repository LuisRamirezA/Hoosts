using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data
{
    public class DataAccess
    {
        public bool RegistrarHotel(Host host )
        {
            var response = false;

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["App.ConnectionString"].ConnectionString))
                {
                    sqlCon.Open();

                    using (var sqlCmnd = new SqlCommand("sp_CreateHost", sqlCon))
                    {
                        sqlCmnd.CommandType = CommandType.StoredProcedure;
                        sqlCmnd.Parameters.AddWithValue("@Nombre", host.Nombre);
                        sqlCmnd.Parameters.AddWithValue("@Email", host.Email);
                        sqlCmnd.Parameters.AddWithValue("@Telefono", host.Telefono);
                        sqlCmnd.Parameters.AddWithValue("@Rfc", host.Rfc);
                        sqlCmnd.Parameters.AddWithValue("@Razon_social", host.RazonSocial);
                        sqlCmnd.Parameters.AddWithValue("@Es_activo", host.EsActivo);

                        var reader = sqlCmnd.ExecuteNonQuery();
                        response = true;
                    }

                }
            }
            catch (Exception ex)
            {


            }
            return response;

        }

        public bool RegistrarHabitacion(Habitacion habitacion)
        {
            var response = false;

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["App.ConnectionString"].ConnectionString))
                {
                    sqlCon.Open();

                    using (var sqlCmnd = new SqlCommand("sp_CreateHabitacion", sqlCon))
                    {
                        sqlCmnd.CommandType = CommandType.StoredProcedure;
                        sqlCmnd.Parameters.AddWithValue("@Nombre", habitacion.Nombre);
                        sqlCmnd.Parameters.AddWithValue("@Descripcion", habitacion.Descripcion);
                        sqlCmnd.Parameters.AddWithValue("@Cantidad", habitacion.Cantidad);
                        sqlCmnd.Parameters.AddWithValue("@Precio", habitacion.Precio);
                        sqlCmnd.Parameters.AddWithValue("@Codigo", habitacion.Codigo);
                        sqlCmnd.Parameters.AddWithValue("@Es_activo", habitacion.EsActivo);
                        sqlCmnd.Parameters.AddWithValue("@Host_id", habitacion.HostId);
                        sqlCmnd.Parameters.AddWithValue("@Tipo_habitacion_id", habitacion.TipoHabitacionId);

                        var reader = sqlCmnd.ExecuteNonQuery();
                        response = true;
                    }

                }
            }
            catch (Exception ex)
            {


            }
            return response;

        }


        public List<Host> ListarHosts(int paginas, int tamanio)
        {
            List<Host> response = new List<Host>();
            

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["App.ConnectionString"].ConnectionString))
                {
                    sqlCon.Open();

                    using (var sqlCmnd = new SqlCommand("sp_GetHosts", sqlCon))
                    {
                        sqlCmnd.CommandType = CommandType.StoredProcedure;
                        sqlCmnd.Parameters.AddWithValue("@PageNumber", paginas);
                        sqlCmnd.Parameters.AddWithValue("@PageSize", tamanio);


                        using (var sqlDtRdr = sqlCmnd.ExecuteReader())
                        {
                            while (sqlDtRdr.Read())
                            {
                                Host host = new Host();
                                host.Id = Convert.ToInt32(string.IsNullOrEmpty(sqlDtRdr["Id"].ToString()) ? "0" : sqlDtRdr["Id"]);
                                host.Nombre = Convert.ToString(string.IsNullOrEmpty(sqlDtRdr["Nombre"].ToString()) ? "0" : sqlDtRdr["Nombre"]);
                                host.Email = Convert.ToString(string.IsNullOrEmpty(sqlDtRdr["Email"].ToString()) ? "0" : sqlDtRdr["Email"]);
                                host.Telefono = Convert.ToString(string.IsNullOrEmpty(sqlDtRdr["Telefono"].ToString()) ? "0" : sqlDtRdr["Telefono"]);
                                host.Rfc = Convert.ToString(string.IsNullOrEmpty(sqlDtRdr["Rfc"].ToString()) ? "0" : sqlDtRdr["Rfc"]);
                                host.RazonSocial = Convert.ToString(string.IsNullOrEmpty(sqlDtRdr["Razon_Social"].ToString()) ? "0" : sqlDtRdr["Razon_Social"]);
                                host.EsActivo = Convert.ToBoolean(string.IsNullOrEmpty(sqlDtRdr["Es_Activo"].ToString()) ? "0" : sqlDtRdr["Es_Activo"]);

                                
                                response.Add(host);
                            }
                        }

                }
            }
            }
            catch (Exception ex)
            {


            }
            return response;

        }

        public List<Habitacion> ListarHabitaciones(string hosts)
        {
            List<Habitacion> response = new List<Habitacion>();


            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["App.ConnectionString"].ConnectionString))
                {
                    sqlCon.Open();

                    using (var sqlCmnd = new SqlCommand("sp_ListHabitacion", sqlCon))
                    {
                        sqlCmnd.CommandType = CommandType.StoredProcedure;
                        sqlCmnd.Parameters.AddWithValue("@IdHosts", hosts);


                        using (var sqlDtRdr = sqlCmnd.ExecuteReader())
                        {
                            while (sqlDtRdr.Read())
                            {
                                Habitacion habitacion = new Habitacion();
                                habitacion.Id = Convert.ToInt32(string.IsNullOrEmpty(sqlDtRdr["Id"].ToString()) ? "0" : sqlDtRdr["Id"]);
                                habitacion.Nombre = Convert.ToString(string.IsNullOrEmpty(sqlDtRdr["Nombre"].ToString()) ? "0" : sqlDtRdr["Nombre"]);
                                habitacion.HostId = Convert.ToInt32(string.IsNullOrEmpty(sqlDtRdr["Host_id"].ToString()) ? "0" : sqlDtRdr["Host_id"]);


                                response.Add(habitacion);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {


            }
            return response;

        }
    }
}
