using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public struct Atencion2
    {
        public int NunAtencion;
        public int NumSolicitud;
        public int NumDni;
        public string Observacion;
        public string FecRegistro;
        public string HoraInicio;
        public string HoraFin;

    }
    public partial class RegistroAtencion : Form
    {
        public RegistroAtencion()
        {
            InitializeComponent();
        }
        

        private void RegistroAtencion_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            MessageQueue mq = new MessageQueue(@".\private$\Sonia");
            mq.Send("Holaaaaaa");
        }

        private void btnRegistrarAten_Click(object sender, EventArgs e)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Atencion atencionACrear = new Atencion();
            atencionACrear.NunAtencion = Convert.ToInt32(txtNumAtencion.Text);
            atencionACrear.NumSolicitud = Convert.ToInt32(txtNumSolicitud.Text);
            atencionACrear.NumDni = Convert.ToInt32(txtMedico.Text);
            atencionACrear.Observacion = txtObservacion.Text;
            atencionACrear.FecRegistro = txtFecha.Text;
            atencionACrear.HoraInicio = txtHinicio.Text;
            atencionACrear.HoraFin = txtHfin.Text;


            //START > IMPLEMENTACIÓN DE COLAS DE MENSAJE
            System.Messaging.Message message = new System.Messaging.Message();
            System.Messaging.Message msg = message;
            msg.Body = atencionACrear;
            MessageQueue msgQ = new MessageQueue(".\\Private$\\in");
            msgQ.Send(msg);
            StringBuilder sb = new StringBuilder();
            sb.Append("                Registro Exitoso");
            sb.Append("\n");
            sb.Append("\n");
            sb.Append("¡Gracias por ser parte de la familia");
            sb.Append("\n");
            sb.Append("                     MEDICAL!");
            MessageBox.Show(sb.ToString(), "Mensaje");
            //END > IMPLEMENTACIÓN DE COLAS DE MENSAJE



            string postdata = js.Serialize(atencionACrear);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.
            Create("http://localhost:50389/Atenciones.svc/Atenciones");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string TramaJson = reader.ReadToEnd();
            Atencion atencionCreado = js.Deserialize<Atencion>(TramaJson);
        }

        private void btnCola_Click(object sender, EventArgs e)
        {
            BandejaMensajes FormBM = new BandejaMensajes();
            FormBM.Show();
        }
    }
}
