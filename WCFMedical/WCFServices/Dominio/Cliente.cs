using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFServices.Dominio
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public int cod_cliente { get; set; }
        [DataMember]
        public string des_nombres { get; set; }
        [DataMember]
        public string des_ape_paterno { get; set; }
        [DataMember]
        public string des_ape_materno { get; set; }
        [DataMember]
        public string fec_nacimiento { get; set; }
        [DataMember]
        public string des_direccion { get; set; }
        [DataMember]
        public string des_distrito { get; set; }
        [DataMember]
        public int num_telefono { get; set; }
        [DataMember]
        public string des_email { get; set; }
        [DataMember]
        public string ind_estado { get; set; }
    }
}
