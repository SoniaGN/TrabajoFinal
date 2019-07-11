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
    class Cliente
    {
        public int cod_cliente { get; set; }

        public string des_nombres { get; set; }

        public string des_ape_paterno { get; set; }

        public string des_ape_materno { get; set; }

        public string fec_nacimiento { get; set; }

        public string des_direccion { get; set; }

        public string des_distrito { get; set; }

        public int num_telefono { get; set; }

        public string des_email { get; set; }

        public string ind_estado { get; set; }
    }
}