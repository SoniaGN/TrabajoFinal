using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFServices.Dominio
{
    [DataContract]
    public class Atencion
    {
        [DataMember]
        public int NunAtencion { get; set; }
        [DataMember]
        public int NumSolicitud { get; set; }
        [DataMember]
        public int NumDni { get; set; }
        [DataMember]
        public string Observacion { get; set; }

        [DataMember]
        public string FecRegistro { get; set; }

        [DataMember]
        public string HoraInicio { get; set; }

        [DataMember]
        public string HoraFin { get; set; }

    }
}