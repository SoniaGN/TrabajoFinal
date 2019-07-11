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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Solicitudes" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Solicitudes.svc o Solicitudes.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Solicitudes : ISolicitudes
    {
        private SolicitudDAO solicitudDAO = new SolicitudDAO();
        public Solicitud CrearSolicitud(Solicitud solicitudACrear)
        {
            Solicitud solicitudExistente = solicitudDAO.Obtener(solicitudACrear.Nu_Solicitud);
            if (solicitudExistente!= null)
            {
                throw new WebFaultException<RepetidoException>(new RepetidoException()
                {
                    Codigo = "102",
                    Descripcion = "Solicitud duplicada"
                }, HttpStatusCode.Conflict);
            }
            return solicitudDAO.Crear(solicitudACrear);
        }
               
        public void EliminarSolicitud(string Nu_Solicitud)
        {
            solicitudDAO.Eliminar(int.Parse(Nu_Solicitud));
        }

        public List<Solicitud> ListarSolicitudes()
        {
            return solicitudDAO.Listar();
        }

        public Solicitud ModificarSolicitud(Solicitud solicitudAModificar)
        {
            return solicitudDAO.Modificar(solicitudAModificar);
        }

        public Solicitud ObtenerSolicitud(string Nu_Solicitud)
        {
            return solicitudDAO.Obtener(int.Parse(Nu_Solicitud));
        }
    }
}