using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFSTMedical
{
    class Medico
    {
        public int Dni { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Sexo { get; set; }

        public string FechaNacimiento { get; set; }

        public string Especialidad { get; set; }

        public string Correo { get; set; }
    }
}
