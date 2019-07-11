using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using WCFServices.Dominio;
using WCFServices.Errores;
using System.ServiceModel.Web;
using System.Data;
using System.Web;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;

namespace WCFServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IClientes" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IClientes
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Clientes", ResponseFormat = WebMessageFormat.Json)]
        Cliente CrearCliente(Cliente clienteACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Clientes/{cod_cliente}", ResponseFormat = WebMessageFormat.Json)]
        Cliente ObtenerCliente(string cod_cliente);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Clientes", ResponseFormat = WebMessageFormat.Json)]
        Cliente ModificarCliente(Cliente clienteAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Clientes/{cod_cliente}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarCliente(string cod_cliente);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Clientes", ResponseFormat = WebMessageFormat.Json)]
        List<Cliente> ListarClientes();
    }
}
