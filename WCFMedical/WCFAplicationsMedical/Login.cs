using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCFAplicationsMedical
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            WCFAplicationsMedical.MenuPrincipal medico1 = new MenuPrincipal();
            medico1.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            WCFAplicationsMedical.RegistroUsuario medico1 = new RegistroUsuario();
            medico1.ShowDialog();
            Show();
        }
    }
}
