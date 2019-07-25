using AppEntities.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Access
{
    public class InvoiceDA :BaseDA
    {
        public int InsertInvoice(Invoice invoice)
        {
            int result = 0;
            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();
                //Inicilizando la transacción
                var transaction = cnx.BeginTransaction(); // Aqui se da el inicio a la transacción
                try
                {
                    var commandCab = cnx.CreateCommand();
                    commandCab.CommandText = "usp_InsertInvoce";
                    commandCab.CommandType = CommandType.StoredProcedure;

                    commandCab.Parameters.Add(
                        new SqlParameter("@CustomerId", invoice.CustomerId)
                        );
                    commandCab.Parameters.Add(
                        new SqlParameter("@InvoiceDate", invoice.InvoiceDate)
                        );
                    commandCab.Parameters.Add(
                        new SqlParameter("@BillingAddress", invoice.BillingAddress)
                        );
                    commandCab.Parameters.Add(
                        new SqlParameter("@BillingCity", invoice.BillingCity)
                        );
                    commandCab.Parameters.Add(
                        new SqlParameter("@BillingState", invoice.BillingState)
                        );
                    commandCab.Parameters.Add(
                        new SqlParameter("@BillingCountry", invoice.BillingCountry)
                        );
                    commandCab.Parameters.Add(
                        new SqlParameter("@BillingPostalCode", invoice.BillingPostalCode)
                        );
                    commandCab.Parameters.Add(
                        new SqlParameter("@Total", invoice.Total)
                        );

                    //Ejecutando y obteniendo el codigo autogenerado
                     var id = Convert.ToInt32(commandCab.ExecuteScalar());

                    foreach (var line in invoice.InvoiceLine)
                    {
                        var commandDet = cnx.CreateCommand();
                        commandDet.CommandText = "usp_InsertInvoceLine";
                        commandDet.CommandType = CommandType.StoredProcedure;

                        commandCab.Parameters.Add(
                            new SqlParameter("@InvoiceId", id)
                            );
                        commandCab.Parameters.Add(
                            new SqlParameter("@TrackId", line.TrackId)
                            );
                        commandCab.Parameters.Add(
                            new SqlParameter("@UnitPrice", line.UnitPrice)
                            );
                        commandCab.Parameters.Add(
                            new SqlParameter("@Quantity", line.Quantity)
                            );

                        commandDet.ExecuteNonQuery();

                    }

                    // Confirmando con la transacción con el commit
                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    transaction.Rollback(); //Deshaciendo la transacción
                }
            }
                       
                return result;
        }
    }
}
