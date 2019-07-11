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
    public struct Medico2
    {
        public int Dni;
        public string Nombre;
        public string ApellidoMaterno;
        public string ApellidoPaterno;
        public string Sexo;
        public string FechaNacimiento;
        public string Especialidad;
        public string Correo;
    }
    public partial class CrearMedico : Form
    {
        public CrearMedico()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Medico medicoACrear = new Medico();

            medicoACrear.Dni = Convert.ToInt32(textBoxDni.Text);
            medicoACrear.Nombre = textBoxNombre.Text;
            medicoACrear.ApellidoPaterno = textBoxApellidoPaterno.Text;
            medicoACrear.ApellidoMaterno = textBoxApellidoMaterno.Text;
            medicoACrear.Sexo = textBoxSexo.Text;
            medicoACrear.FechaNacimiento = textBoxFechaNacimiento.Text;
            medicoACrear.Especialidad = textBoxEspecialidad.Text;
            medicoACrear.Correo = textBoxCorreo.Text;

            //START > IMPLEMENTACIÓN DE COLAS DE MENSAJE
            System.Messaging.Message msg = new System.Messaging.Message();
            msg.Body = medicoACrear;
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

            string postdata = js.Serialize(medicoACrear);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.
                Create("http://localhost:50386/Medicos.svc/Medicos");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string TramaJson = reader.ReadToEnd();
            Medico medicoCreado = js.Deserialize<Medico>(TramaJson);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BandejaMensajes FormBM = new BandejaMensajes();
            FormBM.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CrearMedico_Load(object sender, EventArgs e)
        {

        }
    }
}
