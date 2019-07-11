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
    class Solicitud
    {
        public int Nu_Solicitud { get; set; }

        public int co_Cliente { get; set; }

        public string Direccion { get; set; }

        public string Distrito { get; set; }

        public string fe_registro { get; set; }

        public int dni_medio { get; set; }

        public string observa { get; set; }

        public string estado { get; set; }
    }
}
