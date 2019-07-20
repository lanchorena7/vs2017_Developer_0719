using System;
using App.Data;
using App.Data.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.DataUniTest
{
    [TestClass]
    public class SolicitudUnitTest
    {
        [TestMethod]
        public void SolicitudHWTest()
        {
            SolicitudAcceso obj1 = new SolicitudAcceso();
            obj1.NivelAcceso = 2;

            Assert.IsTrue(obj1.Aprobar(),
                "El usuario administrador no puede aprobar");

            Solicitud obj2 = new SolicitudAcceso()
            {
                    NivelAcceso = 4
            };
            Assert.IsTrue(obj2.Aprobar(),
               "El usuario administrador no puede aprobar");

        }
        [TestMethod]
        public void SolicitudesTest()
        {
            SolicitudHardware obj1 = new SolicitudHardware();
            obj1.Fecha = DateTime.Now;

            Assert.IsTrue(VerificarAprobacion(obj1));
        }

            private bool VerificarAprobacion(Solicitud solicitud)
        {
            return solicitud.Aprobar();
        }
    }
}
