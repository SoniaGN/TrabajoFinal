using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServices.Dominio;
using WCFServices.Errores;
using WCFServices.Persistencia;
using System.Data.SqlClient;
using System.ServiceModel.Web;
using System.Web;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Net;

namespace WCFServices
{
    public class Clientes : IClientes
    {
        private ClienteDAO clienteDAO = new ClienteDAO();
        public Cliente CrearCliente(Cliente clienteACrear)
        {
            Cliente clienteExistente = clienteDAO.Obtener(clienteACrear.cod_cliente);
            if (clienteExistente != null)
            {
                throw new WebFaultException<RepetidoException>(new RepetidoException()
                {
                    Codigo = "102",
                    Descripcion = "Cliente duplicado"
                }, HttpStatusCode.Conflict);
            }
           return clienteDAO.Crear(clienteACrear);
        }
        public Cliente ObtenerCliente(string cod_cliente)
        {
            return clienteDAO.Obtener(int.Parse(cod_cliente));
        }
        public Cliente ModificarCliente(Cliente clienteAModificar)
        {
            return clienteDAO.Modificar(clienteAModificar);
        }

        public void EliminarCliente(string cod_cliente)
        {
            clienteDAO.Eliminar(int.Parse(cod_cliente));
        }

        public List<Cliente> ListarClientes()
        {
            return clienteDAO.Listar();
        }
    }
}