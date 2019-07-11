using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using WCFServices.Dominio;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace WCFServices.Dominio
{
    [DataContract]
    public class Medico
    {
        [DataMember]
        public int Dni { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        public string ApellidoMaterno { get; set; }
        [DataMember]
        public string Sexo { get; set; }
        [DataMember]
        public string FechaNacimiento { get; set; }
        [DataMember]
        public string Especialidad { get; set; }
        [DataMember]
        public string Correo { get; set; }
    }
}