using System.Collections.Generic;
using System.Data.SqlClient;
using WCFServices.Dominio;

namespace WCFServices.Persistencia
{
    public class ClienteDAO
    {
        private string CadenaConexion = "Data Source=(local); Initial Catalog=BD_Medical;Integrated Security=SSPI;";

        public Cliente Crear(Cliente clienteACrear)
        {
            Cliente clienteCreado = null;
            string sql = "INSERT INTO t_cliente VALUES (@codigo, @nombres, @apellidopaterno, @apellidomaterno, @fechanacimiento, @direccion, @distrito, @telefono, @correo, @estado)";
            using (SqlConnection cn = new SqlConnection(CadenaConexion))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add(new SqlParameter("@codigo", clienteACrear.cod_cliente));
                    cmd.Parameters.Add(new SqlParameter("@nombres", clienteACrear.des_nombres));
                    cmd.Parameters.Add(new SqlParameter("@apellidopaterno", clienteACrear.des_ape_paterno));
                    cmd.Parameters.Add(new SqlParameter("@apellidomaterno", clienteACrear.des_ape_materno));
                    cmd.Parameters.Add(new SqlParameter("@fechanacimiento", clienteACrear.fec_nacimiento));
                    cmd.Parameters.Add(new SqlParameter("@direccion", clienteACrear.des_direccion));
                    cmd.Parameters.Add(new SqlParameter("@distrito", clienteACrear.des_distrito));
                    cmd.Parameters.Add(new SqlParameter("@telefono", clienteACrear.num_telefono));
                    cmd.Parameters.Add(new SqlParameter("@correo", clienteACrear.des_email));
                    cmd.Parameters.Add(new SqlParameter("@estado", clienteACrear.ind_estado));
                    cmd.ExecuteNonQuery();
                }
            }
            clienteCreado = Obtener(clienteACrear.cod_cliente);
            return clienteCreado;

        }
        public Cliente Obtener(int cod_cliente)
        {
            Cliente clienteEncontrado = null;
            string sql = "SELECT * FROM t_cliente WHERE cod_cliente=@codigo";
            using (SqlConnection cn = new SqlConnection(CadenaConexion))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add(new SqlParameter("@codigo", cod_cliente));
                    using (SqlDataReader rsl = cmd.ExecuteReader())
                    {
                        if (rsl.Read())
                        {
                            clienteEncontrado = new Cliente()
                            {
                                cod_cliente = (int)rsl["cod_cliente"],
                                des_nombres = (string)rsl["des_nombres"],
                                des_ape_paterno = (string)rsl["des_ape_paterno"],
                                des_ape_materno = (string)rsl["des_ape_materno"],
                                fec_nacimiento = (string)rsl["fec_nacimiento"],
                                des_direccion = (string)rsl["des_direccion"],
                                des_distrito = (string)rsl["des_distrito"],
                                num_telefono = (int)rsl["num_telefono"],
                                des_email = (string)rsl["des_email"],
                                ind_estado = (string)rsl["ind_estado"]
                            };
                        }
                    }
                }
            }
            return clienteEncontrado;
        }

        public Cliente Modificar(Cliente clienteAModificar)
        {
            Cliente clienteModificado = null;
            string sql = "UPDATE t_cliente  SET des_nombres=@nombres, des_ape_paterno=@apellidopaterno, des_ape_materno=@apellidomaterno, " +
                " fec_nacimiento=@fechanacimiento, des_direccion=@direccion, des_distrito=@distrito, num_telefono=@telefono, des_email=@correo," +
                " ind_estado=@estado where cod_cliente=@codigo";

            using (SqlConnection cn = new SqlConnection(CadenaConexion))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add(new SqlParameter("@codigo", clienteAModificar.cod_cliente));
                    cmd.Parameters.Add(new SqlParameter("@nombres", clienteAModificar.des_nombres));
                    cmd.Parameters.Add(new SqlParameter("@apellidopaterno", clienteAModificar.des_ape_paterno));
                    cmd.Parameters.Add(new SqlParameter("@apellidomaterno", clienteAModificar.des_ape_materno));
                    cmd.Parameters.Add(new SqlParameter("@fechanacimiento", clienteAModificar.fec_nacimiento));
                    cmd.Parameters.Add(new SqlParameter("@direccion", clienteAModificar.des_direccion));
                    cmd.Parameters.Add(new SqlParameter("@distrito", clienteAModificar.des_distrito));
                    cmd.Parameters.Add(new SqlParameter("@telefono", clienteAModificar.num_telefono));
                    cmd.Parameters.Add(new SqlParameter("@correo", clienteAModificar.des_email));
                    cmd.Parameters.Add(new SqlParameter("@estado", clienteAModificar.ind_estado));
                    cmd.ExecuteNonQuery();
                }
            }
            clienteModificado = Obtener(clienteAModificar.cod_cliente);
            return clienteModificado;
        }

        public void Eliminar(int codigo)
        {
            string sql = "DELETE FROM t_cliente where cod_cliente=@codigo";

            using (SqlConnection cn = new SqlConnection(CadenaConexion))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add(new SqlParameter("@codigo", codigo));
                    cmd.ExecuteNonQuery();
                }

            }
        }
        public List<Cliente> Listar()
        {
            List<Cliente> clientesEncontrados = new List<Cliente>();
            Cliente clienteEncontrado = null;
            string sql = "SELECT * from t_cliente";
            using (SqlConnection cn = new SqlConnection(CadenaConexion))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    using (SqlDataReader rsl = cmd.ExecuteReader())
                    {
                        while (rsl.Read())
                        {
                            clienteEncontrado = new Cliente()
                            {
                                cod_cliente = (int)rsl["cod_cliente"],
                                des_nombres = (string)rsl["des_nombres"],
                                des_ape_paterno = (string)rsl["des_ape_paterno"],
                                des_ape_materno = (string)rsl["des_ape_materno"],
                                fec_nacimiento = (string)rsl["fec_nacimiento"],
                                des_direccion = (string)rsl["des_direccion"],
                                des_distrito = (string)rsl["des_distrito"],
                                num_telefono = (int)rsl["num_telefono"],
                                des_email = (string)rsl["des_email"],
                                ind_estado = (string)rsl["ind_estado"]
                            };
                            clientesEncontrados.Add(clienteEncontrado);
                        }

                    }
                }
            }
            return clientesEncontrados;

        }

    }
}