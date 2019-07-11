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
    [ServiceContract]
    public interface IAtenciones
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Atenciones", ResponseFormat = WebMessageFormat.Json)]
        Atencion CrearAtencion(Atencion atencionACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Atenciones/{NunAtencion}", ResponseFormat = WebMessageFormat.Json)]
        Atencion ObtenerAtencion(string NunAtencion);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Atenciones", ResponseFormat = WebMessageFormat.Json)]
        Atencion ModificarAtencion(Atencion atencionAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Atenciones/{NunAtencion}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarAtencion(string NunAtencion);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Atenciones", ResponseFormat = WebMessageFormat.Json)]
        List<Atencion> ListarAtenciones();

    }
}