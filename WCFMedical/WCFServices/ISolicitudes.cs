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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ISolicitudes" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISolicitudes
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Solicitudes", ResponseFormat = WebMessageFormat.Json)]
        Solicitud CrearSolicitud(Solicitud SolicitudACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Solicitudes/{Nu_Solicitud}", ResponseFormat = WebMessageFormat.Json)]
        Solicitud ObtenerSolicitud(string Nu_Solicitud);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Solicitudes", ResponseFormat = WebMessageFormat.Json)]
        Solicitud ModificarSolicitud(Solicitud SolicitudAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Solicitudes/{Nu_Solicitud}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarSolicitud(string Nu_Solicitud);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Solicitudes", ResponseFormat = WebMessageFormat.Json)]
        List<Solicitud> ListarSolicitudes();
    }
}