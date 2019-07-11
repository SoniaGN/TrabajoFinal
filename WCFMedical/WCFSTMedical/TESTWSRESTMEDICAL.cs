using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;
using System.Collections.Generic;

namespace WCFSTMedical
{
    [TestClass]
    public class TESTWSRESTMEDICAL
    {
        [TestMethod]
        public void Test1CrearMedico()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Medico medicoACrear = new Medico()
            {
                Dni = 2356798,
                Nombre = "Juan Fabio",
                ApellidoPaterno = "Limaco",
                ApellidoMaterno = "Keller",
                Sexo = "Masculino",
                FechaNacimiento = "13/07/1995",
                Especialidad = "Pediatra",
                Correo = "jlimaco@medical.com"
            };
            string postdata = js.Serialize(medicoACrear);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:50386/Medicos.svc/Medicos");
            request.Method ="POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data,0,data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string TramaJson = reader.ReadToEnd();
            Medico medicoCreado = js.Deserialize<Medico>(TramaJson);
            Assert.AreEqual(2356798, medicoCreado.Dni);
            Assert.AreEqual("Juan Fabio", medicoCreado.Nombre);
            Assert.AreEqual("Limaco", medicoCreado.ApellidoPaterno);
            Assert.AreEqual("Keller", medicoCreado.ApellidoMaterno);
            Assert.AreEqual("Masculino ", medicoCreado.Sexo);
            Assert.AreEqual("13/07/1995", medicoCreado.FechaNacimiento);
            Assert.AreEqual("Pediatra", medicoCreado.Especialidad);
            Assert.AreEqual("jlimaco@medical.com", medicoCreado.Correo);
        }

        [TestMethod]
        public void Test1CrearMedicoDuplicate()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Medico medicoACrear = new Medico()
            {
                Dni = 23234549,
                Nombre = "Juan Fabio",
                ApellidoPaterno = "Limaco",
                ApellidoMaterno = "Keller",
                Sexo = "Masculino",
                FechaNacimiento = "13/07/1995",
                Especialidad = "Pediatra",
                Correo = "jlimaco@medical.com"
            };
            string postdata = js.Serialize(medicoACrear);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.
                Create("http://localhost:50386/Medicos.svc/Medicos");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string TramaJson = reader.ReadToEnd();
                Medico medicoCreado = js.Deserialize<Medico>(TramaJson);
                Assert.AreEqual(23234549, medicoCreado.Dni);
                Assert.AreEqual("Juan Fabio", medicoCreado.Nombre);
                Assert.AreEqual("Limaco", medicoCreado.ApellidoPaterno);
                Assert.AreEqual("Keller", medicoCreado.ApellidoMaterno);
                Assert.AreEqual("Masculino ", medicoCreado.Sexo);
                Assert.AreEqual("13/07/1995", medicoCreado.FechaNacimiento);
                Assert.AreEqual("Pediatra", medicoCreado.Especialidad);
                Assert.AreEqual("jlimaco@medical.com", medicoCreado.Correo);
            } catch (WebException e)
            {
                HttpStatusCode Codigo = ((HttpWebResponse)e.Response).StatusCode;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string tramaJson = reader.ReadToEnd();
                DuplicadoException error = js.Deserialize<DuplicadoException>(tramaJson);
                Assert.AreEqual(HttpStatusCode.Conflict, Codigo);
                Assert.AreEqual("Medico duplicado", error.Descripcion);

            }
        }
        [TestMethod]
        public void Test1ObtenerMedico()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.
                Create("http://localhost:50386/Medicos.svc/Medicos/23234549");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Medico medicoObtenido = js.Deserialize<Medico>(tramaJson);
            Assert.AreEqual("Juan Fabio", medicoObtenido.Nombre);
            Assert.AreEqual("Limaco", medicoObtenido.ApellidoPaterno);
            Assert.AreEqual("Keller", medicoObtenido.ApellidoMaterno);
            Assert.AreEqual("Masculino ", medicoObtenido.Sexo);
            Assert.AreEqual("13/07/1995", medicoObtenido.FechaNacimiento);
            Assert.AreEqual("Pediatra", medicoObtenido.Especialidad);
            Assert.AreEqual("jlimaco@medical.com", medicoObtenido.Correo);

        }
        [TestMethod]
        public void Test20ModificarMedico()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Medico medicoACrear = new Medico()
            {
                Dni = 23234549,
                Nombre = "Juan Fabio Modificado",
                ApellidoPaterno = "Limaco Modificado",
                ApellidoMaterno = "Keller Modificado",
                Sexo = "Masculino",
                FechaNacimiento = "13/07/1995",
                Especialidad = "Pediatra",
                Correo = "jlimaco@medical.com"
            };
            string postdata = js.Serialize(medicoACrear);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.
                Create("http://localhost:50386/Medicos.svc/Medicos");
            request.Method = "PUT";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string TramaJson = reader.ReadToEnd();
            Medico medicoCreado = js.Deserialize<Medico>(TramaJson);
            Assert.AreEqual(23234549, medicoCreado.Dni);
            Assert.AreEqual("Juan Fabio Modificado", medicoCreado.Nombre);
            Assert.AreEqual("Limaco Modificado", medicoCreado.ApellidoPaterno);
            Assert.AreEqual("Keller Modificado", medicoCreado.ApellidoMaterno);
            Assert.AreEqual("Masculino ", medicoCreado.Sexo);
            Assert.AreEqual("13/07/1995", medicoCreado.FechaNacimiento);
            Assert.AreEqual("Pediatra", medicoCreado.Especialidad);
            Assert.AreEqual("jlimaco@medical.com", medicoCreado.Correo);

        }
        [TestMethod]
        public void Test3ListarMedico()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.
                Create("http://localhost:50386/Medicos.svc/Medicos/23234549");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Medico> medicosObtenidos = js.Deserialize<List<Medico>>(tramaJson);
            Assert.AreEqual(4, medicosObtenidos.Count);
          
        }
    }
}
