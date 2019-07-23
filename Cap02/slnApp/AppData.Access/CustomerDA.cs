using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Access
{
    class CustomerDA:BaseDA
    {
        public int GetCount()
        {
            int result = 0;

            try
            {
                //1- Consulta SQL
                var sql = "SELECT COUNT (Customerld) FROM Artist";

                //2- Crear el objeto conexion
                //using (IDbConnection cnx = new SqlConnection(cnxString))
                using (IDbConnection cnx = new SqlConnection(ConnectionString))
                {
                    //Abriendo la conexion a la BD
                    cnx.Open();

                    //3- Creando un objeto command
                    var cmd = cnx.CreateCommand();
                    //Asignando la consulta SQL al objeto command
                    cmd.CommandText = sql;
                    result = (int)cmd.ExecuteScalar(); //Ejecuta el comando
                }
            }
            catch
            {
                result = -1;
            }

            return result;
        }  //TRAE REGISTROS
    }
}
