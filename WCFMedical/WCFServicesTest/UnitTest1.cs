using System;
using System.ServiceModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WCFServicesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1CreacMedicoOK()
        {
            MedicoWS.MedicosClient proxy = new MedicoWS.MedicosClient();
            MedicoWS.Medico medicoCreado = proxy.CrearMedico(new MedicoWS.Medico()
            {
                Dni = 67676776,
                Nombre = "Juan Fabio",
                ApellidoPaterno = "Limaco",
                ApellidoMaterno = "Keller",
                Sexo = "Masculino",
                FechaNacimiento = "13/07/1995",
                Especialidad = "Pediatra",
                Correo = "jlimaco@medical.com"
            });
            Assert.AreEqual(67676776, medicoCreado.Dni);
            Assert.AreEqual("Juan Fabio", medicoCreado.Nombre);
            Assert.AreEqual("Limaco", medicoCreado.ApellidoPaterno);
            Assert.AreEqual("Keller", medicoCreado.ApellidoMaterno);
            Assert.AreEqual("Masculino ", medicoCreado.Sexo);
            Assert.AreEqual("13/07/1995", medicoCreado.FechaNacimiento);
            Assert.AreEqual("Pediatra", medicoCreado.Especialidad);
            Assert.AreEqual("jlimaco@medical.com", medicoCreado.Correo);
        }
        [TestMethod]
        public void Test2CrearMedicoRepetido()
        {
            MedicoWS.MedicosClient proxy = new MedicoWS.MedicosClient();
            try
            {
                MedicoWS.Medico medicoCreado = proxy.CrearMedico(new MedicoWS.Medico()
                {
                    Dni = 67676776,
                    Nombre = "Juan Fabio",
                    ApellidoPaterno = "Limaco",
                    ApellidoMaterno = "Keller",
                    Sexo = "Masculino",
                    FechaNacimiento = "13/07/1995",
                    Especialidad = "Pediatra",
                    Correo = "jlimaco@medical.com"
                });
            }
            catch (FaultException<MedicoWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al intentar creación", error.Reason.ToString());
                Assert.AreEqual(error.Detail.Codigo, "101";
                Assert.AreEqual(error.Detail.Descripcion, "El medico ya existe");
            }
        }
    }
}
