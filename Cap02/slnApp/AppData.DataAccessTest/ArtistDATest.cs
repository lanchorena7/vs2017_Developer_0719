using System;
using AppData.Access;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppData.DataAccessTest
{
    [TestClass]
    public class ArtistDATest
    {
        [TestMethod]
        public void Count()
        {
            var da = new ArtistDA();
            var cantidad = da.GetCount();

            Assert.IsTrue(cantidad > 0);
        }

        [TestMethod]
        public void GetArtist()
        {
            var da = new ArtistDA();
            var listado = da.GetArtist();

            Assert.IsTrue(listado.Count >= 0);
        }

        [TestMethod]
        public void GetArtistWitSP()
        {
            var da = new ArtistDA();
            var listado = da.GetArtist("Aero%");

            Assert.IsTrue(listado.Count >= 0);
        }
    }
}
