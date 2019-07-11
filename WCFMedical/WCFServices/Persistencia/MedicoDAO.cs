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
    public class MedicoDAO
    {
        private string CadenaConexion = "Data Source=(local); Initial Catalog=BD_Medical;Integrated Security=SSPI;";

        public Medico Crear(Medico medicoACrear)
        {
            Medico medicoCreado = null;
            string sql = "INSERT INTO t_medico VALUES (@dni, @nombre, @apellidopaterno, @apellidomaterno, @sexo, @fechanacimiento, @especialidad, @correo)";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", medicoACrear.Dni));
                    comando.Parameters.Add(new SqlParameter("@nombre", medicoACrear.Nombre));
                    comando.Parameters.Add(new SqlParameter("@apellidopaterno", medicoACrear.ApellidoPaterno));
                    comando.Parameters.Add(new SqlParameter("@apellidomaterno", medicoACrear.ApellidoMaterno));
                    comando.Parameters.Add(new SqlParameter("@sexo", medicoACrear.Sexo));
                    comando.Parameters.Add(new SqlParameter("@fechanacimiento", medicoACrear.FechaNacimiento));
                    comando.Parameters.Add(new SqlParameter("@especialidad", medicoACrear.Especialidad));
                    comando.Parameters.Add(new SqlParameter("@correo", medicoACrear.Correo));
                    comando.ExecuteNonQuery();
                }
            }
            medicoCreado = Obtener(medicoACrear.Dni);
            return medicoCreado;
        }
        public Medico Obtener(int dni)
        {
            Medico medicoEncontrado = null;
            string sql = "SELECT * FROM t_medico WHERE nu_dni=@dni";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", dni));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            medicoEncontrado = new Medico()
                            {
                                Dni = (int)resultado["nu_dni"],
                                Nombre = (string)resultado["tx_nombre"],
                                ApellidoPaterno = (string)resultado["tx_apellidopaterno"],
                                ApellidoMaterno = (string)resultado["tx_apellidomaterno"],
                                Sexo = (string)resultado["tx_Sexo"],
                                FechaNacimiento = (string)resultado["fe_nacimiento"],
                                Especialidad = (string)resultado["tx_especialidad"],
                                Correo = (string)resultado["tx_correo"]
                            };
                        }
                    }
                }
            }
            return medicoEncontrado;
        }
        public Medico Modificar(Medico medicoAModificar)
        {
            Medico medicoModificado = null;
            string sql = "UPDATE t_medico SET tx_nombre=@nombre, tx_apellidopaterno=@apellidopaterno, tx_apellidomaterno=@apellidomaterno," +
                " tx_sexo=@sexo, fe_nacimiento=@fechanacimiento, tx_especialidad=@especialidad, tx_correo=@correo WHERE nu_dni=@dni";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                 
                    comando.Parameters.Add(new SqlParameter("@nombre", medicoAModificar.Nombre));
                    comando.Parameters.Add(new SqlParameter("@apellidopaterno", medicoAModificar.ApellidoPaterno));
                    comando.Parameters.Add(new SqlParameter("@apellidomaterno", medicoAModificar.ApellidoMaterno));
                    comando.Parameters.Add(new SqlParameter("@sexo", medicoAModificar.Sexo));
                    comando.Parameters.Add(new SqlParameter("@fechanacimiento", medicoAModificar.FechaNacimiento));
                    comando.Parameters.Add(new SqlParameter("@especialidad", medicoAModificar.Especialidad));
                    comando.Parameters.Add(new SqlParameter("@correo", medicoAModificar.Correo));
                    comando.Parameters.Add(new SqlParameter("@dni", medicoAModificar.Dni));
                    comando.ExecuteNonQuery();
                }
            }
            medicoModificado = Obtener(medicoAModificar.Dni);
            return medicoModificado;
        }
        public List<Medico> Listar()
        {
            List<Medico> medicosEncontrados = new List<Medico>();
            Medico medicoEncontrado = null;
            string sql = "SELECT * from t_medico";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            medicoEncontrado = new Medico()
                            {
                                Dni = (int)resultado["nu_dni"],
                                Nombre = (string)resultado["tx_nombre"],
                                ApellidoPaterno = (string)resultado["tx_apellidopaterno"],
                                ApellidoMaterno = (string)resultado["tx_apellidomaterno"],
                                Sexo = (string)resultado["tx_Sexo"],
                                FechaNacimiento = (string)resultado["fe_nacimiento"],
                                Especialidad = (string)resultado["tx_especialidad"],
                                Correo = (string)resultado["tx_correo"]
                            };
                            medicosEncontrados.Add(medicoEncontrado);
                        }

                    }
                }
            }
            return medicosEncontrados;
              
        }

    }
}