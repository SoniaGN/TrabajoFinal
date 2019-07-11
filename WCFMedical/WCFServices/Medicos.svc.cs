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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Medicos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Medicos.svc o Medicos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Medicos : IMedicos
    {
        private MedicoDAO medicoDAO = new MedicoDAO();
        public Medico CrearMedico(Medico medicoACrear)
        {
            Medico medicoExistente = medicoDAO.Obtener(medicoACrear.Dni);
            if (medicoExistente !=null) // Ya existe
            {
                throw new WebFaultException<RepetidoException>(new RepetidoException
                    {
                        Codigo = "102",
                        Descripcion = "Medico duplicado"
                    }, HttpStatusCode.Conflict);
                 
            }
            return medicoDAO.Crear(medicoACrear);
        }
        public Medico ObtenerMedico(string dni)
        {
            return medicoDAO.Obtener(int.Parse(dni));
        }
        public Medico ModificarMedico(Medico medicoAModificar)
        {
            return medicoDAO.Modificar(medicoAModificar);

        }
        
        public List<Medico> ListarMedicos()
        {
            return medicoDAO.Listar();
        }
    }
}
