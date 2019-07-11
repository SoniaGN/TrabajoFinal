using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCFServices.Dominio;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServices.Errores;
using WCFServices.Persistencia;
using System.ServiceModel.Web;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;


namespace WCFServices.Persistencia
{
    public class SolicitudDAO
    {
        private string CadenaConexion = "Data Source=(local); Initial Catalog=BD_Medical;Integrated Security=SSPI;";

        public Solicitud Crear(Solicitud SolicitudACrear)
        {
            Solicitud SolicitudCreada = null;
            string sql = "INSERT INTO t_solicitud VALUES(@num_soli,@cod_cli,@direccion,@distrito,@fecha,@dniM,@observacion,@estado)";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {

                    comando.Parameters.Add(new SqlParameter("@num_soli", SolicitudACrear.Nu_Solicitud));
                    comando.Parameters.Add(new SqlParameter("@cod_cli", SolicitudACrear.co_Cliente));
                    comando.Parameters.Add(new SqlParameter("@direccion", SolicitudACrear.Direccion));
                    comando.Parameters.Add(new SqlParameter("@distrito", SolicitudACrear.Distrito));
                    comando.Parameters.Add(new SqlParameter("@fecha", SolicitudACrear.fe_registro));
                    comando.Parameters.Add(new SqlParameter("@dniM", SolicitudACrear.dni_medio));
                    comando.Parameters.Add(new SqlParameter("@observacion", SolicitudACrear.observa));
                    comando.Parameters.Add(new SqlParameter("@estado", SolicitudACrear.estado));
                    comando.ExecuteNonQuery();

                }
            }
            SolicitudCreada = Obtener(SolicitudACrear.Nu_Solicitud);
            return SolicitudCreada;
        }

        public Solicitud Obtener(int Nu_Solicitud)
        {
            Solicitud SolicitudEncontrada = null;
            string sql = "SELECT * FROM t_solicitud WHERE num_solicitud=@num_soli";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@num_soli", Nu_Solicitud));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            SolicitudEncontrada = new Solicitud()
                            {
                                Nu_Solicitud = (int)resultado["num_solicitud"],
                                co_Cliente = (int)resultado["cod_cliente"],
                                Direccion = (string)resultado["des_direccion"],
                                Distrito = (string)resultado["des_distrito"],
                                fe_registro = (string)resultado["fec_registro"],
                                dni_medio = (int)resultado["nu_dni_medico"],
                                observa = (string)resultado["des_observacion"]

                            };
                        }
                    }
                }
            }
            return SolicitudEncontrada;
        }
        public Solicitud Modificar(Solicitud SolicitudaModificar)
        {
            Solicitud SolicitudModificada = null;
            string sql = "UPDATE t_solicitud SET cod_cliente=@cod_cli,des_direccion=@direccion,des_distrito=@distrito," +
                "fec_registro=@fecha,nu_dni_medico=@dniM,des_observacion=@observacion,ind_estado=@estado num_solicitud=@num_soli" ;
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@num_soli", SolicitudaModificar.Nu_Solicitud));
                    comando.Parameters.Add(new SqlParameter("@cod_cli", SolicitudaModificar.co_Cliente));
                    comando.Parameters.Add(new SqlParameter("@direccion", SolicitudaModificar.Direccion));
                    comando.Parameters.Add(new SqlParameter("@distrito", SolicitudaModificar.Distrito));
                    comando.Parameters.Add(new SqlParameter("@fecha", SolicitudaModificar.fe_registro));
                    comando.Parameters.Add(new SqlParameter("@dniM", SolicitudaModificar.dni_medio));
                    comando.Parameters.Add(new SqlParameter("@observacion", SolicitudaModificar.observa));
                    comando.Parameters.Add(new SqlParameter("@estado", SolicitudaModificar.estado));
                    comando.ExecuteNonQuery();

                }
            }
            SolicitudModificada = Obtener(SolicitudaModificar.Nu_Solicitud);
            return SolicitudModificada;

        }
        public void Eliminar(int Nu_Solicitud)
        {
            string sql = "DELETE FROM t_solicitud WHERE num_solicitud=@num_soli";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@num_soli", Nu_Solicitud));
                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<Solicitud> Listar()
        {
            List<Solicitud> SolicitudesEncontradas = new List<Solicitud>();
            Solicitud SolicitudEncontrada = null;
            string sql = "SELECT * FROM t_solicitud";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            SolicitudEncontrada = new Solicitud()
                            {
                                Nu_Solicitud = (int)resultado["num_solicitud"],
                                co_Cliente = (int)resultado["cod_cliente"],
                                Direccion = (string)resultado["des_direccion"],
                                Distrito = (string)resultado["des_distrito"],
                                fe_registro = (string)resultado["fec_registro"],
                                dni_medio = (int)resultado["nu_dni_medico"],
                                observa = (string)resultado["des_observacion"]

                            };
                            SolicitudesEncontradas.Add(SolicitudEncontrada);
                        }
                    }
                }
            }
            return SolicitudesEncontradas;
        }

    }
}