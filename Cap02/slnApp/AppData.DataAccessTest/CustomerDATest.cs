using System;
using AppData.Access;
using AppEntities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppData.DataAccessTest
{
    [TestClass]
    public class GetCustomerxName
    {
        [TestMethod]
        public void GetCustomerxName()
        {
            var da = new Customer();
            var lista = da.GetCustomerxName("");

            Assert.IsTrue(lista.Count > 0);
        }

    }
}
