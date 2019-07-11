using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFServices.Dominio
{
    [DataContract]
    public class Solicitud
    {
        [DataMember]
        public int Nu_Solicitud { get; set; }
        [DataMember]
        public int co_Cliente { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Distrito { get; set; }
        [DataMember]
        public string fe_registro { get; set; }
        [DataMember]
        public int dni_medio { get; set; }
        [DataMember]
        public string observa { get; set; }
        [DataMember]
        public string estado { get; set; }
    }
}