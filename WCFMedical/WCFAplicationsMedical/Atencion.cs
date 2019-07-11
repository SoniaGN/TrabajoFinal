using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Web;
using System.Data.SqlClient;
using System.ServiceModel;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;
using System.Messaging;
using System.Xml;
using System.Xml.Serialization;

namespace WCFAplicationsMedical
{
    public struct Atencion
    {
        public int NunAtencion { get; set; }

        public int NumSolicitud { get; set; }

        public int NumDni { get; set; }

        public string Observacion { get; set; }

        public string FecRegistro { get; set; }

        public string HoraInicio { get; set; }

        public string HoraFin { get; set; }
    }
}