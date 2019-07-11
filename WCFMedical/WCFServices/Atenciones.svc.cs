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
    public class Atenciones : IAtenciones
    {
        private AtencionDAO atencionDAO = new AtencionDAO();
        public Atencion CrearAtencion(Atencion atencionACrear)
        {
            Atencion atencionExistente = atencionDAO.Obtener(atencionACrear.NunAtencion);
            if (atencionExistente !=null)
            {
                throw new WebFaultException<RepetidoException>(new RepetidoException()
                {
                    Codigo = "102",
                    Descripcion = "Atención duplicada"
                }, HttpStatusCode.Conflict);                    
            }
            return atencionDAO.Crear(atencionACrear);
        }

        public Atencion ObtenerAtencion(string NunAtencion)
        {
            return atencionDAO.Obtener(int.Parse(NunAtencion));
        }

        public Atencion ModificarAtencion(Atencion atencionAModificar)
        {
            return atencionDAO.Modificar(atencionAModificar);
        }

        public void EliminarAtencion(string NunAtencion)
        {
            atencionDAO.Eliminar(int.Parse(NunAtencion));
        }
        public List<Atencion> ListarAtenciones()
        {
            return atencionDAO.Listar();
        }

    }
}