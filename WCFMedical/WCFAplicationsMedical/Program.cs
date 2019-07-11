using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCFAplicationsMedical
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.77777
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new CrearMedico());
            Application.Run(new MenuPrincipal());
        }
    }
}
