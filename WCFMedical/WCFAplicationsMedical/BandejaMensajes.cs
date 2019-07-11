using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCFAplicationsMedical
{
    public partial class BandejaMensajes : Form
    {
        public BandejaMensajes()
        {
            InitializeComponent();
        }

        private void btnBandejaEn_Click(object sender, EventArgs e)
        {
           
        }

        private void btnMensLinea_Click(object sender, EventArgs e)
        {
            MessageQueue msgQ = new MessageQueue(".\\Private$\\in");
            Atencion atencionACrear = new Atencion();
            Object o = new Object();
            System.Type[] arrTypes = new System.Type[2];
            arrTypes[0] = atencionACrear.GetType();
            arrTypes[1] = o.GetType();
            msgQ.Formatter = new XmlMessageFormatter(arrTypes);
            atencionACrear = ((Atencion)msgQ.Receive().Body);
            StringBuilder sb = new StringBuilder();
            sb.Append("El Medico");
            sb.Append("\n");
            sb.Append("con N° de Solicitud: " + atencionACrear.NumSolicitud);
            sb.Append("\n");
            sb.Append("\n");
            sb.Append("Se ha registrado en la plataforma Medical");
            sb.Append("\n");
            MessageBox.Show(sb.ToString(), "Mensaje");
        }
    }
}
