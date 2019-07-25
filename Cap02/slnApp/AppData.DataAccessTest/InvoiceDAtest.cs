using System;
using System.Collections.Generic;
using AppEntities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppData.DataAccessTest
{
    [TestClass]
    public class InvoiceDAtest
    {
        [TestMethod]
        public void Insert()
        {
            var invoice = new Invoice();
            invoice.CustomerId = 1;
            invoice.InvoiceDate = DateTime.Now;
            invoice.BillingAddress = "";
            invoice.BillingCity = "";
            invoice.BillingState = "";
            invoice.BillingCountry = "";
            invoice.BillingPostalCode = "";
            invoice.Total = 100;

            invoice.InvoiceLine = new List<InvoiceLine>();

            invoice.InvoiceLine.Add(
                new InvoiceLine()
                {
                    TrackId = 1,
                    UnitPrice = 10,
                    Quantity = 3
                }
            );

            invoice.InvoiceLine.Add(
                new InvoiceLine()
                {
                    TrackId = 2,
                    UnitPrice = 10,
                    Quantity = 7
                }
            );
        }

    internal class List<T> : System.Collections.Generic.List<InvoiceLine>
    {
    }
}
}
