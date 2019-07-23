using System;
using AppData.Access;
using AppEntities.Base;
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

        [TestMethod]
        public void InsertArtist()
        {
            var artist = new Artist();
            artist.Name = "Artista prueba";

            var da = new ArtistDA();
            var codigoGenerado = da.InsertArtist(artist);

            Assert.IsTrue(codigoGenerado > 0);
        }

        [TestMethod]
        public void InsertArtistParamOut()
        {
            var artist = new Artist();
            artist.Name = "Artista prueba";

            var da = new ArtistDA();
            var codigoGenerado = da.InsertArtistParamOut(artist);

            Assert.IsTrue(codigoGenerado > 0);
        }
    }
}
